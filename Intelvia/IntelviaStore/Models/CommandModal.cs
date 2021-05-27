using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Models
{
    public class CommandModal
    {
        public int Id { get; set; }

        public DateTime DateCmd { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ProductModel> ProductModel { get; set; }
    }
}
