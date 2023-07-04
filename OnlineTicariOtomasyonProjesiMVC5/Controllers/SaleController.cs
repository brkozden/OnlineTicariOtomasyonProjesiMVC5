using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{

    public class SaleController : Controller
    {
        public void bringValues()
        {
            List<SelectListItem> value1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.productName,
                                               Value = x.productId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.currentName + " " + x.currentSurname,
                                               Value = x.currentId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.employeeName + " " + x.employeeSurname,
                                               Value = x.employeeId.ToString()
                                           }).ToList();
            ViewBag.value1 = value1;
            ViewBag.value2 = value2;
            ViewBag.value3 = value3;
        }
        // GET: Sale
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.SaleTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult newSale()
        {
            bringValues();
            return View();
        }
        [HttpPost]
        public ActionResult newSale(SaleTransaction st)
        {
            st.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaleTransactions.Add(st);
            context.SaveChanges();
            return RedirectToAction("Index");
     
        }
        public ActionResult bringSale(int id)
        {
            bringValues();
            var saleValue = context.SaleTransactions.Find(id);
            return View("bringSale",saleValue);
        }
        public ActionResult updateSale(SaleTransaction st)
        {
            var sale = context.SaleTransactions.Find(st.saleId);
            sale.productId = st.productId;
            sale.currentId = st.currentId;
            sale.employeeId = st.employeeId;
            sale.count = st.count;
            sale.price = st.price;
            sale.total = st.total;
            sale.date = st.date;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult detailSale(int id)
        {
            var values = context.SaleTransactions.Where(x => x.saleId == id).ToList();
            return View(values);
        }
        public ActionResult SaleList()
        {
            var values = context.SaleTransactions.ToList();
            return View(values);

        }
    }
}