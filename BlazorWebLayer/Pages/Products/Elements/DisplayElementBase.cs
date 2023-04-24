using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Products.Elements
{
    public class DisplayElementBase : ComponentBase
    {
        [Parameter]
        public VElement Element { get; set; }
        [Parameter]
        public bool ShowAction { get; set; }
        [Parameter]
        public bool WindowAdd { get; set; }

        [Inject]
        public IElementService elementService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public EventCallback<int> OnElementDeleted { get; set; }
        [Parameter]
        public EventCallback<(bool,int)> OnElementSelected { get; set; }
        [Parameter]
        public EventCallback<(bool, int, int)> OnMultipleElementCount { get; set; }

        protected bool IsSelected { get; set; }

        protected BlazorWebLayer.Pages.Custom.ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await elementService.Remove(Element.ElementId);
                await OnElementDeleted.InvokeAsync(Element.ElementId);
            }
        }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            Element.IsChecked = (bool)e.Value;
            await OnElementSelected.InvokeAsync((Element.IsChecked, Element.ElementId));
        }

        protected async Task SubElementCountChanged(ChangeEventArgs e)
        {
            if (Element.IsChecked)
            {
                await OnMultipleElementCount.InvokeAsync((Element.IsChecked, Element.ElementId, Convert.ToInt32(e.Value)));
            }
        }
    }
}
