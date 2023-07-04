using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
  
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index(string p, int page = 1)
        {
           
         var values = context.Products.Where((y => y.productName.Contains(p) || y.Brand.Contains(p) || y.categories.categoryName.Contains(p) || p == null)).ToList().ToPagedList(page, 10);
           
            return View(values);
        }

        [HttpGet]
        public ActionResult addProduct()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.categoryName,
                                               Value = x.categoryId.ToString()
                                           }).ToList();

            ViewBag.categoryValue = values;
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Product p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "/Image/Products/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                p.productImg = "/Image/Products/" + fileName + extension;
            }
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult deleteProduct(int id)
        {
            var value = context.Products.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult bringProduct(int id)
        {
            var productValue = context.Products.Find(id);
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.categoryName,
                                               Value = x.categoryId.ToString()
                                           }).ToList();

            ViewBag.categoryValue = values;
            return View("bringProduct", productValue);
        }
        public ActionResult updateProduct(Product p) 
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "/Image/Products/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                p.productImg = "/Image/Products/" + fileName + extension;
            }
            var product = context.Products.Find(p.productId);
         
            product.productName = p.productName;
            product.Brand = p.Brand;
            product.Stock = p.Stock;
            product.purchasePrice = p.purchasePrice;
            product.salePrice = p.salePrice;
            product.Status = p.Status;
            product.productImg = p.productImg;
            product.categoryId = p.categoryId;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult sell(int id)
        {
            List<SelectListItem> employee = (from x in context.Employees.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.employeeName + " " + x.employeeSurname,
                                                 Value = x.employeeId.ToString()
                                             }).ToList();
            ViewBag.employee = employee;
            var product = context.Products.Find(id);
            ViewBag.product = product.productId;
            ViewBag.productPrice = product.salePrice;
            return View();
        }
        [HttpPost]
        public ActionResult sell(SaleTransaction s)
        {
                s.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                context.SaleTransactions.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index", "Sale");

        }
    }
}