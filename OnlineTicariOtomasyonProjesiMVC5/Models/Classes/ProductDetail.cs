using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class ProductDetail
    {
        [Key]
        public int detailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string productName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string productInfo { get; set; }
    }
}