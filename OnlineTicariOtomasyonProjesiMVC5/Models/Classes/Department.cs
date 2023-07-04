using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Department
    {
        [Key]
        public int departmentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string departmentName { get; set; }

        public bool Status { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}