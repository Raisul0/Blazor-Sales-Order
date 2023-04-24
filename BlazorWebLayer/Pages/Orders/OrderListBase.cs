using BusinessLogicLayer.Interfaces.Orders;
using DomainLayer.VModels.Orders;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Orders
{
    public class OrderListBase : ComponentBase
    {
        [Inject]
        public IOrderService orderService { get; set; }

        public List<VOrder> Orders { get; set; }

        [Parameter]
        public EventCallback<int> OnOrderDeleted { get; set; }

        public bool ShowAction { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Orders = await orderService.GetAllOrdersWithWindows();
        }

        protected async Task OrderDeleted()
        {
            Orders = await orderService.GetAllOrdersWithWindows();
        }

    }
}
