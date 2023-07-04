using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int cargoTrackingId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string trackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string explanation { get; set; }
        public DateTime date { get; set; }
    }
}