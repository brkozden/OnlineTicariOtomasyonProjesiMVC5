using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{

    public class ToDoController : Controller
    {
        // GET: ToDo
        Context context = new Context();
        public ActionResult Index()
        {
            var current = context.Currents.Count().ToString();
            ViewBag.currents = current;
            var products = context.Products.Count().ToString();
            ViewBag.products = products;
            var categories = context.Categories.Count().ToString();
            ViewBag.categories = categories;
            var sale = context.SaleTransactions.Count().ToString();
            ViewBag.sale = sale;
            var total = context.SaleTransactions.Sum(x=>x.total).ToString();
            ViewBag.total = total;
            var doList = context.ToDoLists.ToList();
            return View(doList);
        }
    }
}