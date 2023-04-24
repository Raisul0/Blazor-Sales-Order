using DomainLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository.Products
{
    public interface IWindowRepo : IGenericRepository<Window>
    {
        Task<List<Window>> GetAllWindowsWithElements();
        int GetWindowQuantity(int orderId, int windowId);
        Task<Window> GetWindowWithElements(int windowid);
        Task<List<WindowElement>> AddWindowElements(Window window, List<Element> elements);
    }
}
