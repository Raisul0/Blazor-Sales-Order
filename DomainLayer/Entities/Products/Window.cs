using DomainLayer.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Products
{
    public class Window
    {
        public int WindowId { get; set; }
        public string WindowName { get; set; }

        public virtual ICollection<WindowElement> WindowElements { get; set; }
        public virtual ICollection<OrderWindow> OrderWindows { get; set; }

        [NotMapped]
        public List<Element> Elements { get; set; }
        [NotMapped]
        public int WindowQuantity { get; set; }
        [NotMapped]
        public int OrderId { get; set; }
    }
}
