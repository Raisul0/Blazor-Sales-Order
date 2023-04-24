using DataAccessLayer.IRepository.Locations;
using DomainLayer.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Locations
{
    public class StateRepo : GenericRepository<State> , IStateRepo
    {
        private readonly WebContext _context;

        public StateRepo(WebContext context) : base(context)
        {
            _context = context;
        }
    }
}
