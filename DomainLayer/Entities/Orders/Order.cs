using DomainLayer.Entities.Locations;
using DomainLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        public virtual ICollection<OrderWindow> OrderWindows { get; set; }

        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public List<Window> Windows { get; set; }
    }
}
