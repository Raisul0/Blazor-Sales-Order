using DataAccessLayer.IRepository.Orders;
using DataAccessLayer.IRepository.Products;
using DomainLayer.Entities.Locations;
using DomainLayer.Entities.Orders;
using DomainLayer.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Orders
{
    public class OrderRepo : GenericRepository<Order> , IOrderRepo
    {
        private readonly WebContext _context;
        private readonly IWindowRepo _windowrepo;

        public OrderRepo(WebContext context,IWindowRepo windowrepo) : base(context)
        {
            _context = context;
            _windowrepo = windowrepo;
        }

        public async Task<List<Order>> GetAllOrderWithWindows()
        {
            var orders = await this.GetAllWithRelationalObjects(nameof(State));
            orders.ForEach(x => {

                var windows = (from w in _context.Windows
                               join oe in _context.OrderWindows on w.WindowId equals oe.WindowId
                               join o in _context.Orders on oe.OrderId equals o.OrderId
                               where o.OrderId == x.OrderId
                               select new Window { WindowId=w.WindowId,WindowName=w.WindowName, OrderId=o.OrderId}).ToList();
                windows.ForEach(y => {
                    y.Elements =  (from w in _context.Windows
                                          join we in _context.WindowElements on w.WindowId equals we.WindowId
                                          join e in _context.Elements on we.ElementId equals e.ElementId
                                          join et in _context.ElementTypes on e.ElementTypeId equals et.ElementTypeId
                                          where w.WindowId == y.WindowId
                                          select new Element { ElementId = e.ElementId, ElementTypeId = e.ElementTypeId, ElementTypeName = et.ElementTypeName, Width = e.Width, Height = e.Height, ElementType = et }).ToList();
                    y.WindowQuantity = _context.OrderWindows.FirstOrDefault(o => o.OrderId == x.OrderId && o.WindowId == y.WindowId)?.WindowQuantity ?? 0;
                });
                x.Windows = windows;
            });

            return orders;
        }

        public async Task<Order> GetOrderWithWindow(int orderId)
        {
            var order = await this.GetByIdAsync(orderId);
            var windows =  (from w in _context.Windows
                           join oe in _context.OrderWindows on w.WindowId equals oe.WindowId
                           join o in _context.Orders on oe.OrderId equals o.OrderId
                           where o.OrderId == orderId
                           select w).ToList();
            windows.ForEach(y => {
                var elements = (from w in _context.Windows
                                join we in _context.WindowElements on w.WindowId equals we.WindowId
                                join e in _context.Elements on we.ElementId equals e.ElementId
                                join et in _context.ElementTypes on e.ElementTypeId equals et.ElementTypeId
                                where w.WindowId == y.WindowId
                                select new Element { ElementId = e.ElementId, ElementTypeId = e.ElementTypeId, ElementTypeName = et.ElementTypeName, Width = e.Width, Height = e.Height, ElementType = et }).ToList();
                y.Elements = elements;
            });

            order.Windows = windows;
            return order;
        }

        public async Task<List<OrderWindow>> AddWindowElements(Order order, List<Window> windows)
        {
            var orderWindows = new List<OrderWindow>();
            var dbWindows = await _context.OrderWindows.Where(x => x.OrderId == order.OrderId).ToListAsync();
            dbWindows.ForEach(x => {
                _context.OrderWindows.Remove(x);
            });
            _context.SaveChanges();

            windows.ForEach(x => {
                orderWindows.Add(new OrderWindow { OrderId = order.OrderId, WindowId = x.WindowId });
                _context.OrderWindows.Add(new OrderWindow { OrderId = order.OrderId, WindowId = x.WindowId, WindowQuantity=x.WindowQuantity });
            });

            return orderWindows;
        }
    }
}
