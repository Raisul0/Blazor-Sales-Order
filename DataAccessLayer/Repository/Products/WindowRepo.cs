using DataAccessLayer.IRepository.Products;
using DomainLayer.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Products
{
    public class WindowRepo : GenericRepository<Window> , IWindowRepo
    {
        private readonly WebContext _context;

        public WindowRepo(WebContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Window>> GetAllWindowsWithElements()
        {
            var windows = await this.GetAllAsync();
            windows.ForEach(x => {

                var elements = (from w in _context.Windows
                                      join we in _context.WindowElements on w.WindowId equals we.WindowId
                                      join e in _context.Elements on we.ElementId equals e.ElementId
                                      join et in _context.ElementTypes on e.ElementTypeId equals et.ElementTypeId
                                      where w.WindowId == x.WindowId
                                      select new Element { ElementId=e.ElementId,ElementTypeId=e.ElementTypeId,ElementTypeName=et.ElementTypeName,Width=e.Width,Height=e.Height,ElementType=et }).ToList();
                x.Elements = elements;
            });
            

            return windows;
        }

        public async Task<Window> GetWindowWithElements(int windowid)
        {
            var window = await this.GetByIdAsync(windowid);
            var elements = await (from w in _context.Windows
                            join we in _context.WindowElements on w.WindowId equals we.WindowId
                            join e in _context.Elements on we.ElementId equals e.ElementId
                            join et in _context.ElementTypes on e.ElementTypeId equals et.ElementTypeId
                            where w.WindowId == windowid
                            select new Element { ElementId = e.ElementId, ElementTypeId = e.ElementTypeId, ElementTypeName = et.ElementTypeName, Width = e.Width, Height = e.Height, ElementType = et }).ToListAsync();

            window.Elements = elements;
            return window;
        }

        public int GetWindowQuantity(int orderId, int windowId)
        {
            return _context.OrderWindows.FirstOrDefault(x => x.OrderId == orderId && x.WindowId == windowId).WindowQuantity;
        }

        public async Task<List<WindowElement>> AddWindowElements(Window window,List<Element> elements)
        {   
            var windowSubElements = new List<WindowElement>();
            var dbElements = await _context.WindowElements.Where(x => x.WindowId == window.WindowId).ToListAsync();
            dbElements.ForEach(x => {
                _context.WindowElements.Remove(x);
            });
            _context.SaveChanges();

            elements.ForEach(x => {
                for (var i = 0; i < x.ElementCount; i++)
                {
                    windowSubElements.Add(new WindowElement { WindowId = window.WindowId, ElementId = x.ElementId });
                    _context.WindowElements.Add(new WindowElement { WindowId = window.WindowId, ElementId = x.ElementId });
                }
            });

            return windowSubElements;
        }
    }
}
