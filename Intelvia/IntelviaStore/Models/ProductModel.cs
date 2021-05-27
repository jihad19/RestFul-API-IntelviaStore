using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Models
{
    public class ProductModel
    {
        [Key]
        [ForeignKey("CategoryId")]
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string TypeProduct { get; set; }
        public string ImageUrl { get; set; }
        //public IFormFile Files { get; set; }
        
        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }
        public virtual ICollection<CommandModal> CommandModal { get; set; }

    }
}
