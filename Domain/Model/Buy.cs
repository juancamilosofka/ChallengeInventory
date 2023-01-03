using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Buy
    {
        [Key]
        public int BuyId { get; set; }
        public DateTime Date { get; set; }
        public string IdType { get; set; }
        public string Id { get; set; }
        public string ClientName { get; set; }
        public List<ProductList> ProductList { get; set; }
    }
}
