using DomainLayer.Entities.Orders;
using DomainLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository.Orders
{
    public interface IOrderRepo : IGenericRepository<Order>
    {
        Task<List<Order>> GetAllOrderWithWindows();
        Task<Order> GetOrderWithWindow(int orderId);
        Task<List<OrderWindow>> AddWindowElements(Order order, List<Window> windows);
    }
}
