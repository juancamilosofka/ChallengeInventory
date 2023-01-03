using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductPagination
    {
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize {get; set;}
        public List<Product> products { get; set;} = new List<Product>();
    }
}
