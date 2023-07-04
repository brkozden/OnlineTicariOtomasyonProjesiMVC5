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

    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int page =1)
        {
            var values = c.Categories.ToList().ToPagedList(page,4);
            return View(values);
        }
        [HttpGet]
        public ActionResult addCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addCategory(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult removeCategory(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult bringCategory(int id)
        {
            var category = c.Categories.Find(id);
            return View("bringCategory", category);
        }
        public ActionResult updateCategory(Category k)
        {
            var ctgr = c.Categories.Find(k.categoryId);
            ctgr.categoryName = k.categoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}