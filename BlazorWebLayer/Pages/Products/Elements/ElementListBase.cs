using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Products.Elements
{
    public class ElementListBase : ComponentBase
    {
        [Inject]
        public IElementService elementService { get; set; }

        public List<VElement> Elements { get; set; }

        [Parameter]
        public EventCallback<int> OnElementDeleted { get; set; }

        public bool ShowAction { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Elements = await elementService.GetAllElementsWithElementType();
        }

        protected async Task ElementDeleted()
        {
            Elements = await elementService.GetAllElementsWithElementType();
        }
    }
}
