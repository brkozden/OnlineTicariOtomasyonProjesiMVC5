using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{

    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();
        public ActionResult Index()
        {
            var totalCustomer = context.Currents.Count().ToString();
            ViewBag.totalCustomer = totalCustomer;
            var totalProduct = context.Products.Count().ToString();
            ViewBag.totalProduct = totalProduct;
            var totalEmployee = context.Employees.Count().ToString();
            ViewBag.totalEmployee = totalEmployee;
            var totalCategory = context.Categories.Count().ToString();
            ViewBag.totalCategory = totalCategory;
            var totalStock = context.Products.Sum(x=>x.Stock).ToString();
            ViewBag.totalStock = totalStock;
            var brandCount = (from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.brandCount = brandCount;
            var criticalLevel = context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.criticalLevel = criticalLevel;
            var maxPriceProduct = (from x in context.Products orderby x.salePrice descending select x.productName).First().ToString();
            ViewBag.maxPriceProduct = maxPriceProduct;
            var minPriceProduct = (from x in context.Products orderby x.salePrice ascending select x.productName).First().ToString();
            ViewBag.minPriceProduct = minPriceProduct;
            var freezerCount = context.Products.Count(x=>x.productName=="Buzdolabi").ToString();
            ViewBag.freezerCount = freezerCount;
            var laptopCount = context.Products.Count(x => x.productName == "Laptop").ToString();
            ViewBag.laptopCount = laptopCount;
            var total = context.SaleTransactions.Sum(x => x.total).ToString();
            ViewBag.total = total;
            DateTime today = DateTime.Today;
            var todaySale = context.SaleTransactions.Count(x => x.date == today);
            ViewBag.todaySale = todaySale;
            var todayTotal = context.SaleTransactions.Where(x=>x.date == today).Sum(x=>(decimal?)x.total).ToString();
            ViewBag.todayTotal = todayTotal;
            var maxBrand = context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y=>y.Key).FirstOrDefault().ToString();
            ViewBag.maxBrand = maxBrand;
            var topSeller = from SaleTransaction in context.SaleTransactions

                            join Product in context.Products on SaleTransaction.productId equals Product.productId

                            group SaleTransaction by SaleTransaction.products.productName into grp

                            select new

                            {

                                UrunAd = grp.Key,

                                Adet = grp.Sum(x => x.count)

                            };
            ViewBag.topSeller = topSeller.OrderByDescending(x => x.Adet).ToList().FirstOrDefault().UrunAd; ;
            return View();
        }
    }
}