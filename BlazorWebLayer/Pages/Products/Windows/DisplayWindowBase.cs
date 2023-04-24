using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Products.Windows
{
    public class DisplayWindowBase : ComponentBase
    {
        [Parameter]
        public VWindow Window { get; set; }
        [Parameter]
        public bool ShowAction { get; set; }
        [Parameter]
        public bool OrderAdd { get; set; }
        [Parameter]
        public bool ShowWindowCount { get; set; }

        [Inject]
        public IWindowService windowService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public EventCallback<int> OnWindowDeleted { get; set; }
        [Parameter]
        public EventCallback<(bool, int)> OnWindowSelected { get; set; }
        [Parameter]
        public EventCallback<(bool,int, int)> OnQuantityChanged { get; set; }

        protected BlazorWebLayer.Pages.Custom.ConfirmBase DeleteConfirmation { get; set; }


        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await windowService.Remove(Window.WindowId);
                await OnWindowDeleted.InvokeAsync(Window.WindowId);
            }
        }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            Window.IsChecked = (bool)e.Value;
            await OnWindowSelected.InvokeAsync((Window.IsChecked, Window.WindowId));
        }

        protected async Task WindowQuantityChanged(ChangeEventArgs e)
        {
            await OnQuantityChanged.InvokeAsync((Window.IsChecked, Window.WindowId, Convert.ToInt32(e.Value)));
        }
    }
}
