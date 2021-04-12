using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string TypeProduct { get; set; }
        public int StockProduct { get; set; }
    }
}
