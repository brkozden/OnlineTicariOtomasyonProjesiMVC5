using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string employeeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string employeeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string employeeImage { get; set; }

        public ICollection<SaleTransaction> saleTransactions { get; set; }
        public int departmentId { get; set; }
        public virtual Department departments { get; set; }

       
    }
}