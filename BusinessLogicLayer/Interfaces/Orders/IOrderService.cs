using DomainLayer.Entities.Orders;
using DomainLayer.VModels.Orders;
using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.Orders
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<List<VOrder>> GetAllOrdersWithWindows();
        Task<VOrder> GetOrderWithWindows(int windowId);
        Task<VOrder> UpdateOrder(VOrder vWindow, List<VWindow> windows);
        Task<VOrder> CreateOrder(VOrder vWindow, List<VWindow> windows);
    }
}
