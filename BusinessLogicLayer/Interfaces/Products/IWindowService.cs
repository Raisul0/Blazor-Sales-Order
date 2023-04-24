using DomainLayer.Entities.Products;
using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.Products
{
    public interface IWindowService : IGenericService<Window>
    {
        Task<List<VWindow>> GetAllWindowsWithElements();
        Task<VWindow> GetWindowWithElements(int windowId);
        int GetWindowQuantity(int orderId, int windowId);
        Task<VWindow> UpdateWindow(VWindow vWindow, List<VElement> elements);
        Task<VWindow> CreateWindow(VWindow vWindow, List<VElement> elements);
    }
}
