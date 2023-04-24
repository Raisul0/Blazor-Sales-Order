using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Products.Elements
{
    public class EditElementBase : ComponentBase
    {
        [Inject]
        public IElementService elementService { get; set; }
        [Inject]
        public IElementTypeService elementTypeService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected BlazorWebLayer.Pages.Custom.ConfirmBase DeleteConfirmation { get; set; }

        public VElement Element { get; set; } = new VElement();
        public List<VElementType> ElementTypes { get; set; } = new List<VElementType>();

        [Parameter]
        public string ElementId { get; set; }
        public string PageHeader { get; set; }


        protected override async Task OnInitializedAsync()
        {
            int.TryParse(ElementId, out int elementId);

            if (elementId != 0)
            {
                PageHeader = "Edit Element";
                Element = await elementService.GetElementWithElementType(int.Parse(ElementId));
            }
            else
            {
                PageHeader = "Create Element";
                Element = new VElement();
                Element.ElementTypeId = 1;
            }

            ElementTypes = await elementTypeService.GetAllElementTypes();
            
        }

        protected async Task HandleValidSubmit()
        {
            VElement result = null;
            if(Element.ElementId != 0)
            {
                result = await elementService.UpdateElement(Element);
            }
            else
            {
                result = await elementService.CreateElement(Element);
            }

            if (result != null)
            {
                navigationManager.NavigateTo("/element");
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
                await elementService.Remove(Element.ElementId);
                navigationManager.NavigateTo("/element");
            }
        }
    }
}
