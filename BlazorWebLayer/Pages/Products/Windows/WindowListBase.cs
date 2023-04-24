using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Products.Windows
{
    public class WindowListBase : ComponentBase
    {
        [Inject]
        public IWindowService windowService { get; set; }

        public List<VWindow> Windows { get; set; }

        [Parameter]
        public EventCallback<int> OnWindowDeleted { get; set; }

        public bool ShowAction { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Windows = await windowService.GetAllWindowsWithElements();
        }

        protected async Task WindowDeleted()
        {
            Windows = await windowService.GetAllWindowsWithElements();
        }
    }
}
