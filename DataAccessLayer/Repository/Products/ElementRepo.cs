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
    public class ElementRepo : GenericRepository<Element> , IElementRepo
    {
        private readonly WebContext _context;

        public ElementRepo(WebContext context) : base(context)
        {
            _context = context;
        }

        public int GetSubElementCount(int windowId,int elementId)
        {
            return _context.WindowElements.Count(x => x.WindowId == windowId && x.ElementId == elementId);
        }

    }
}
