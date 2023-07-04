using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Cost
    {
        [Key]
        public int costId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string explanation { get; set; }

        public DateTime date { get; set; }

        public decimal total { get; set; }
    }
}