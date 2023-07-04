using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
  
    public class CurrentController : Controller
    {
        // GET: Current
        Context context = new Context();
        public ActionResult Index(int page = 1)
        {
            var values = context.Currents.Where(x => x.status == true).ToList().ToPagedList(page, 10);
            return View(values);
        }

        [HttpGet]
        public ActionResult addCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addCurrent(Current c)
        {
            c.status = true;
            context.Currents.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult removeCurrent(int id)
        {
            var cr = context.Currents.Find(id);
            cr.status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult bringCurrent(int id)
        {
            var current = context.Currents.Find(id);

            return View("bringCurrent", current);
        }
        public ActionResult updateCurrent(Current c)
        {
            if (!ModelState.IsValid)
            {
                return View("bringCurrent");
            }
            var current = context.Currents.Find(c.currentId);
            current.currentName = c.currentName;
            current.currentSurname = c.currentSurname;
            current.currentCity = c.currentCity;
            current.currentMail = c.currentMail;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult saleCustomer(int id)
        {
            var saleList = context.SaleTransactions.Where(x => x.currentId == id).ToList();
            var crnm = context.Currents.Where(x => x.currentId == id).Select(y => y.currentName + " " + y.currentSurname).FirstOrDefault();
            ViewBag.crnm = crnm;
            return View(saleList);
        }
        public ActionResult detailsCurrents()
        {
            var currentQuery = context.Currents.ToList();
            return View(currentQuery);

        }
    }
}