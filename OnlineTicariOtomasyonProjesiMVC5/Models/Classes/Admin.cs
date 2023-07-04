using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Admin
    {
        [Key]
        public int adminId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string userName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string password { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string authorization { get; set; }
    }
}