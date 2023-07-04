using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Message
    {
        [Key]
        public int messageId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string receiver { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string subject { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string text { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime date { get; set; }
    }
}