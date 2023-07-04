using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int invoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string invoiceSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string invoiceSequenceNo { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string taxOffice { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string consigner { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string recipient { get; set; }

        public decimal total { get; set; }
        public ICollection<InvoicePencil> invoicePencils { get; set; }
    }
}