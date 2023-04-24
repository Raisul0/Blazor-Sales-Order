using DataAccessLayer.IRepository.Locations;
using DataAccessLayer.IRepository.Orders;
using DataAccessLayer.IRepository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IElementTypeRepo ElementType { get; }
        IElementRepo Element { get; }
        IWindowRepo Window { get; }
        
        IOrderRepo Order { get; }
        IStateRepo State{ get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
