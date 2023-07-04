using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class CargoDetails
    {
        [Key]
        public int cargoId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string explanation { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string trackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string seller { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string buyer { get; set; }
        public DateTime date { get; set; }
    }
}