using BusinessLogicLayer.Interfaces.Locations;
using BusinessLogicLayer.Interfaces.Orders;
using BusinessLogicLayer.Interfaces.Products;
using DomainLayer.VModels.Locations;
using DomainLayer.VModels.Orders;
using DomainLayer.VModels.Products;
using Microsoft.AspNetCore.Components;

namespace BlazorWebLayer.Pages.Orders
{
    public class EditOrderBase : ComponentBase
    {
        [Inject]
        public IOrderService orderService { get; set; }
        [Inject]
        public IWindowService windowService { get; set; }
        [Inject]
        public IStateService stateService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected BlazorWebLayer.Pages.Custom.ConfirmBase DeleteConfirmation { get; set; }

        public VOrder Order { get; set; } = new VOrder();
        public List<VState> States { get; set; } = new List<VState>();
        public List<VWindow> Windows { get; set; } = new List<VWindow> { };

        [Parameter]
        public string OrderId { get; set; }
        public string PageHeader { get; set; }

        public List<VWindow> forAddWindows { get; set; } = new List<VWindow> { };

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(OrderId, out int orderId);

            if (orderId != 0)
            {
                PageHeader = "Edit Window";
                Order = await orderService.GetOrderWithWindows(orderId);
                forAddWindows = Order.Windows.DistinctBy(x => x.WindowId).ToList();
                forAddWindows.ForEach(x =>
                {
                    x.IsChecked = true;
                    x.WindowQuantity = windowService.GetWindowQuantity(orderId, x.WindowId);
                });
            }
            else
            {
                PageHeader = "Create Window";
                Order = new VOrder();
                Order.StateId = 1;
                Order.Windows = new List<VWindow>();

            }

            States = await stateService.GetAllStates();
            Windows = await windowService.GetAllWindowsWithElements();
            Windows.ForEach(x => {
                if (Order.Windows.Any(e => e.WindowId == x.WindowId))
                {
                    x.IsChecked = true;
                    x.WindowQuantity = windowService.GetWindowQuantity(orderId, x.WindowId);
                }
                else
                {
                    x.IsChecked = false;
                    x.WindowQuantity = 0;
                }
            });
        }

        protected async Task HandleValidSubmit()
        {
            VOrder result = null;
            if (Order.OrderId != 0)
            {
                result = await orderService.UpdateOrder(Order,forAddWindows);
            }
            else
            {
                result = await orderService.CreateOrder(Order, forAddWindows);
            }

            if (result != null)
            {
                navigationManager.NavigateTo("/order");
            }
        }

        protected async Task WindowSelectionChanged(bool isSelected, int windowId)
        {
            if (isSelected)
            {
                forAddWindows.Add(new VWindow { WindowId = windowId, WindowQuantity = 1 });
                Windows.FirstOrDefault(x => x.WindowId == windowId).WindowQuantity = 1;
            }
            else
            {
                forAddWindows.Remove(forAddWindows.FirstOrDefault(x => x.WindowId == windowId));
                Windows.FirstOrDefault(x => x.WindowId == windowId).WindowQuantity = 0;
            }

        }

        protected async Task WindowQuantityChange(bool isSelected, int windowId, int windowQuantity)
        {
            if (isSelected)
            {
                if (windowQuantity == 0)
                {
                    forAddWindows.Remove(forAddWindows.FirstOrDefault(x => x.WindowId == windowId));
                    Windows.FirstOrDefault(x => x.WindowId == windowId).IsChecked = false;
                }
                else
                {
                    if (forAddWindows.Any(x => x.WindowId == windowId))
                    {
                        forAddWindows.FirstOrDefault(x => x.WindowId == windowId).WindowQuantity = windowQuantity;
                    }
                    else
                    {
                        forAddWindows.Add(new VWindow { WindowId = windowId, WindowQuantity = windowQuantity });
                    }
                }
                Windows.FirstOrDefault(x => x.WindowId == windowId).WindowQuantity = windowQuantity;
            }
            else
            {

                forAddWindows.Remove(forAddWindows.FirstOrDefault(x => x.WindowId == windowId));
                Windows.FirstOrDefault(x => x.WindowId == windowId).WindowQuantity = 0;
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
                await orderService.Remove(Order.OrderId);
                navigationManager.NavigateTo("/order");
            }
        }
    }
}
