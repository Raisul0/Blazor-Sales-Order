using BusinessLogicLayer.Interfaces.Orders;
using DomainLayer.VModels.Orders;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Orders
{
    public class DisplayOrderBase : ComponentBase
    {
        [Parameter]
        public VOrder Order { get; set; }
        [Parameter]
        public bool ShowAction { get; set; }

        [Inject]
        public IOrderService orderService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public EventCallback<int> OnOrderDeleted { get; set; }

        protected BlazorWebLayer.Pages.Custom.ConfirmBase DeleteConfirmation { get; set; }


        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await orderService.Remove(Order.OrderId);
                await OnOrderDeleted.InvokeAsync(Order.OrderId);
            }
        }
    }
}
