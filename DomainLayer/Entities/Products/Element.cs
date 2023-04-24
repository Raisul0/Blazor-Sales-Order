using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Products
{
    public class Element
    {
        public int ElementId { get; set; }
        
        public int Height { get; set; }
        public int Width { get; set; }

        public int ElementTypeId { get; set; }
        public virtual ElementType ElementType { get; set; }

        public virtual ICollection<WindowElement> WindowElements { get; set; }

        [NotMapped]
        public string ElementTypeName { get; set; }
        [NotMapped]
        public int ElementCount { get; set; }
    }
}
