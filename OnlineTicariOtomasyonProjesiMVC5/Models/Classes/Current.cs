using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Current
    {
        [Key]
        public int currentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazılmalıdır.")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz.")]
        public string currentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazılmalıdır.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string currentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter yazılmalıdır.")]
        public string currentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter yazılmalıdır.")]
        public string currentMail { get; set; }
        public ICollection<SaleTransaction> saleTransactions { get; set; }

        public bool status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter yazılmalıdır.")]
        public string password { get; set; }
    }
}