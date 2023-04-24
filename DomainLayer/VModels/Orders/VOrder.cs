using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.VModels.Orders
{
    public class VOrder
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Name Is Mandatory")]
        public string OrderName { get; set; }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public List<VWindow> Windows { get; set; }
    }
}
