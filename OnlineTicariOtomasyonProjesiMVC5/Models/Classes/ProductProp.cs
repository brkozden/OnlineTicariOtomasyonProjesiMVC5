using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class ProductProp
    {
        public IEnumerable<Product> value1 { get; set; }
        public IEnumerable<ProductDetail> value2 { get; set; }
    }
}