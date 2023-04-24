using DomainLayer.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Locations
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
