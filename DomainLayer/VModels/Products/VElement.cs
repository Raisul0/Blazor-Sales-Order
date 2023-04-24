using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.VModels.Products
{
    public class VElement
    {
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        [DisplayName("Type")]
        public string ElementTypeName { get; set; }

        [Required(ErrorMessage ="Height Is Mandatory")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Width Is Mandatory")]
        public int Width { get; set; }

        public bool IsChecked { get; set; }
        public int ElementCount { get; set; }

    }
}
