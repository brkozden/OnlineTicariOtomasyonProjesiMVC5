using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;
using System.Web.Security;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
 [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult registerCurrent()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult registerCurrent(Current c)
        {
            context.Currents.Add(c);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult loginCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginCurrent(Current c)
        {
            var info = context.Currents.FirstOrDefault(x => x.currentMail == c.currentMail && x.password == c.password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.currentMail, false);
                Session["currentMail"] = info.currentMail.ToString();
                return RedirectToAction("Index", "BuyingPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
           
             
        }
        [HttpGet]
        public ActionResult adminLogin()
        {
            return View();
        }
      
        public ActionResult adminLogin(Admin p)
        {
            var infoAdmin = context.Admins.FirstOrDefault(x => x.userName == p.userName && x.password == p.password);
            if (infoAdmin != null)
            {
                FormsAuthentication.SetAuthCookie(infoAdmin.userName,false);
                Session["username"] = infoAdmin.userName.ToString();
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}