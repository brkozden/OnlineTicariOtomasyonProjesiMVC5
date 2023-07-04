using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class InvoicePencil
    {
        [Key]
        public int invoicePencilId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string explanation { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal total { get; set; }
        public int invoiceId { get; set; }
        public virtual Invoice invoices { get; set; }
    }
}