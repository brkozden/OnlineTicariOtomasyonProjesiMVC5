using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
 
    public class CargoController : Controller
    {
        // GET: Cargo
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var cargoList = from x in context.CargoDetails select x ;

            if (!string.IsNullOrEmpty(p))
            {
                cargoList = cargoList.Where(y => y.trackingCode.Contains(p));
            }
          
            return View(cargoList.ToList());
        }
        [HttpGet]
        public ActionResult newCargo()
        {
            Random rnd = new Random();
            string[] character = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
              int k1,k2,k3;
            k1 = rnd.Next(0, character.Length);
            k2 = rnd.Next(0, character.Length);
            k3 = rnd.Next(0, character.Length);
            int s1, s2, s3;
             s1 = rnd.Next(100, 1000);
             s2 = rnd.Next(10, 99);
             s3 = rnd.Next(10, 99);
            string cargoCode = s1.ToString() + character[k1] + s2.ToString() + character[k2] + s3.ToString() + character[k3];
            ViewBag.trackingCode = cargoCode;


            return View();
        }
        [HttpPost]
        public ActionResult newCargo(CargoDetails c)
        {
            context.CargoDetails.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult cargoTracking(string id)
        {

            var cargo = context.CargoTrackings.Where(x => x.trackingCode == id).ToList();

           
            return View(cargo);
        }
    }
}