using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductList
    {
        [Key]
        public int ProductListId { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
