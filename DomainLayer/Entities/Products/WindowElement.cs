using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Products
{
    public class WindowElement
    {
        public int WindowElementId { get; set; }

        public int WindowId { get; set; }
        public virtual Window Window { get; set; }
        public int ElementId { get; set; }
        public virtual Element Element { get; set; }


    }
}
