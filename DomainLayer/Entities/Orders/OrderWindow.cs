using DomainLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Orders
{
    public class OrderWindow
    {
        public int OrderWindowId { get; set; }


        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int WindowId { get; set; }
        public virtual Window Window { get; set; }

        public int WindowQuantity { get; set; }
    }
}
