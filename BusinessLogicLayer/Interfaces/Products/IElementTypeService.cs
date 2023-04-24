using DomainLayer.Entities.Products;
using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.Products
{
    public interface IElementTypeService : IGenericService<ElementType>
    {
        Task<List<VElementType>> GetAllElementTypes();
    }
}
