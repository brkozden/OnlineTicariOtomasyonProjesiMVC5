using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class SaleTransaction
    {
        [Key]
        public int saleId { get; set; }
       

        public DateTime date { get; set; }

        public int count { get; set; }

        public decimal price { get; set; }
        public decimal total { get; set; }

        public int productId { get; set; }
        public int currentId { get; set; }
        public int employeeId { get; set; }
        public virtual Product products { get; set; }
        public virtual Current currents { get; set; }
        public virtual Employee employees { get; set; }
    }
}