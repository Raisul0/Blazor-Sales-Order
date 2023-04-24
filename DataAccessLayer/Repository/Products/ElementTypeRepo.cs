using DataAccessLayer.IRepository.Products;
using DomainLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Products
{
    public class ElementTypeRepo : GenericRepository<ElementType> , IElementTypeRepo
    {
        private readonly WebContext _context;

        public ElementTypeRepo(WebContext context) : base(context)
        {
            _context = context;
        }
    }
}
