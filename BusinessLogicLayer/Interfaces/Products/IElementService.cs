using DomainLayer.Entities.Products;
using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.Products
{
    public interface IElementService : IGenericService<Element>
    {
        Task<List<VElement>> GetAllElements();
        Task<List<VElement>> GetAllElementsWithElementType();
        Task<VElement> GetElementWithElementType(int elementId);
        int GetSubElementCount(int windowId, int elementId);
        Task<VElement> UpdateElement(VElement vElement);
        Task<VElement> CreateElement(VElement vElement);
    }
}
