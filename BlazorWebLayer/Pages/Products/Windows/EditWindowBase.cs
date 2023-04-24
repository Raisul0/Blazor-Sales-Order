using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace BlazorWebLayer.Pages.Products.Windows
{
    public class EditWindowBase : ComponentBase
    {
        [Inject]
        public IWindowService windowService { get; set; }
        [Inject]
        public IElementService elementService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected BlazorWebLayer.Pages.Custom.ConfirmBase DeleteConfirmation { get; set; }

        public VWindow Window { get; set; } = new VWindow();
        public List<VElement> Elements { get; set; } = new List<VElement> { };

        [Parameter]
        public string WindowId { get; set; }
        public string PageHeader { get; set; }
        [Parameter]
        public EventCallback<(bool,int)> OnElementSelected { get; set; }
        //[Parameter]
        //public EventCallback<(bool, int, int)> OnMultipleElementCount { get; set; }

        public List<VElement> elements { get; set; } = new List<VElement> { };

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(WindowId, out int windowId);

            if (windowId != 0)
            {
                PageHeader = "Edit Window";
                Window = await windowService.GetWindowWithElements(int.Parse(WindowId));
                elements = Window.Elements.DistinctBy(x=>x.ElementId).ToList();
                elements.ForEach(x =>
                {
                    x.IsChecked = true;
                    x.ElementCount = elementService.GetSubElementCount(windowId, x.ElementId);
                });
            }
            else
            {
                PageHeader = "Create Window";
                Window = new VWindow();
            }

            Elements = await elementService.GetAllElementsWithElementType();
            Elements.ForEach(x => {
                if (elements.Any(e=> e.ElementId==x.ElementId))
                {
                    x.IsChecked = true;
                    x.ElementCount = elementService.GetSubElementCount(windowId,x.ElementId);
                }
                else
                {
                    x.IsChecked = false;
                    x.ElementCount = 0;
                }
            });
        }

        protected async Task HandleValidSubmit()
        {
            VWindow result = null;
            if(Window.WindowId != 0)
            {
                result = await windowService.UpdateWindow(Window,elements);
            }
            else
            {
                result = await windowService.CreateWindow(Window, elements);
            }

            if (result != null)
            {
                navigationManager.NavigateTo("/window");
            }
        }

        protected async Task ElementSelectionChanged(bool isSelected,int elementId)
        {
            if (isSelected)
            {
                elements.Add(new VElement { ElementId = elementId, ElementCount = 1 });
                Elements.FirstOrDefault(x => x.ElementId == elementId).ElementCount = 1;
            }
            else
            {
                elements.Remove(elements.FirstOrDefault(x => x.ElementId == elementId));
                Elements.FirstOrDefault(x => x.ElementId == elementId).ElementCount = 0;
            }
        }

        protected async Task MultipleElementCount(bool isSelected, int elementId,int elementCount)
        {
            if (isSelected)
            {
                if (elementCount == 0)
                {
                    elements.Remove(elements.FirstOrDefault(x => x.ElementId == elementId));
                    Elements.FirstOrDefault(x => x.ElementId == elementId).IsChecked = false;
                }
                else
                {
                    if (elements.Any(x => x.ElementId == elementId))
                    {
                        elements.FirstOrDefault(x => x.ElementId == elementId).ElementCount = elementCount;
                    }
                    else
                    {
                        elements.Add(new VElement { ElementId = elementId, ElementCount = elementCount });
                    }
                }
                Elements.FirstOrDefault(x => x.ElementId == elementId).ElementCount = elementCount;
            }
            else
            {

                elements.Remove(elements.FirstOrDefault(x => x.ElementId == elementId));
                Elements.FirstOrDefault(x => x.ElementId == elementId).ElementCount = 0;
            }
        }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await windowService.Remove(Window.WindowId);
                navigationManager.NavigateTo("/window");
            }
        }
    }
}
