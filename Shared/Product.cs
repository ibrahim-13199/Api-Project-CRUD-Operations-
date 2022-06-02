using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Shared
{
    public class Product
    {
            public int Id { get; set; }
            [Required]
            [MaxLength(25)]
            [MinLength(3, ErrorMessage = "Name Must Be More Than 2 Char")]
            public string name { get; set; }
            [Required]
            public decimal price { get; set; }
            [Required]
            public string Image { get; set; }

            [Required(ErrorMessage = "Describtion Required !")]
            public string Describtion { get; set; }

            [ForeignKey("categoryRelation")]
            public int cat_Id { get; set; }
            
            public virtual Category categoryRelation { get; set; }

    }
}
