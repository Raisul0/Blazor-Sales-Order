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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebContext _context;

        public IElementTypeRepo ElementType { get; }
        public IElementRepo Element { get; }
        public IWindowRepo Window { get; }
        public IOrderRepo Order { get; }
        public IStateRepo State { get; }

        public UnitOfWork(WebContext context, IElementTypeRepo elementTypeRepo, IElementRepo elementRepo,IWindowRepo windowRepo,IOrderRepo orderRepo,IStateRepo stateRepo)
        {
            _context = context;
            ElementType = elementTypeRepo;
            Element = elementRepo;
            Window = windowRepo;
            Order = orderRepo;
            State= stateRepo;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
