using DomainLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository.Products
{
    public interface IElementRepo : IGenericRepository<Element>
    {
        int GetSubElementCount(int windowId, int elementId);
    }
}
