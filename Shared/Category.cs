using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shared
{
    [Index( nameof(Category.name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3, ErrorMessage = "Name Must Be More Than 2 Char")]
      
        public string? name { get; set; }
        //[Required(ErrorMessage = "Describtion Required !")]
        public string Describtion { get; set; }

        //naviagtio prop 
        //[JsonIgnore]
        public virtual List<Product> Prouducts { get; set; }=new List<Product>();
    }
}
