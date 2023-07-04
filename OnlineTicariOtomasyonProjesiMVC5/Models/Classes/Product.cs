using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string productName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }

        public short Stock { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salePrice { get; set; }

        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string productImg { get; set; }

        public int categoryId { get; set; }
        public virtual Category categories { get; set; }
        public ICollection<SaleTransaction> saleTransactions { get; set; }
    }
}