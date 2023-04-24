using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.VModels.Products
{
    public class VWindow
    {
        public int WindowId { get; set; }
        [Required(ErrorMessage = "Name Is Mandatory")]
        public string WindowName { get; set; }
        public int TotalSubElements { get; set; }
        public int WindowQuantity { get; set; }

        public List<VElement> Elements { get; set; }
        public bool IsChecked { get; set; }
    }
}
