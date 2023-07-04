using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string categoryName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}