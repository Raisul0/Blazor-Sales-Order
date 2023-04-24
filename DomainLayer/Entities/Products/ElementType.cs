using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Products
{
    public class ElementType
    {
        public int ElementTypeId { get; set; }
        public string ElementTypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Element> Elements { get; set; }
    }
}
