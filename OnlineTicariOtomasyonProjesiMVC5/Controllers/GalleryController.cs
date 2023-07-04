using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
 
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}