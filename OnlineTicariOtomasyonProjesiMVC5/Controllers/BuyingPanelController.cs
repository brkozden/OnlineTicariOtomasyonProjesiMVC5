using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
  
    public class BuyingPanelController : Controller
    {
        Context context = new Context();
        // GET: BuyingPanel
        


        public ActionResult Index()
        {
            var mail = (string)Session["currentMail"];
            var mailId = context.Currents.Where(x => x.currentMail == mail).Select(y=>y.currentId).FirstOrDefault();
            ViewBag.mailId = mailId;
            var value = context.Messages.Where(x => x.receiver == mail).ToList();
          
            var totalSale = context.SaleTransactions.Where(x => x.currentId == mailId).Count();
            ViewBag.totalSale = totalSale;
            var totalprice = context.SaleTransactions.Where(x => x.currentId == mailId).Sum(y => y.total).ToString();
            ViewBag.totalprice = totalprice;
            var totalProduct = context.SaleTransactions.Where(x => x.currentId == mailId).Sum(y => y.count).ToString();
            ViewBag.totalProduct = totalProduct;
            var nameSurname = context.Currents.Where(x => x.currentId == mailId).Select(y => y.currentName + " " + y.currentSurname).FirstOrDefault();
            ViewBag.nameSurname = nameSurname;
            var city = context.Currents.Where(x => x.currentId == mailId).Select(y => y.currentCity).FirstOrDefault();
            ViewBag.city = city;

            ViewBag.mail = mail;
        
            return View(value);
        }
       
        public ActionResult myOrders()
        {
            var mail = (string)Session["currentMail"];
            var id = context.Currents.Where(x => x.currentMail == mail.ToString()).Select(y => y.currentId).FirstOrDefault();
            var values = context.SaleTransactions.Where(x => x.currentId == id).ToList();
            return View(values);
        }
   
        public ActionResult incomingMessages()
        {
            var mail = (string)Session["currentMail"];
            var messages = context.Messages.Where(x => x.receiver == mail).OrderByDescending(x=>x.messageId).ToList();
            var incomingCount = context.Messages.Count(x => x.receiver == mail).ToString();
            ViewBag.incomingCount = incomingCount;
            var sentCount = context.Messages.Count(x => x.sender == mail).ToString();
            ViewBag.sentCount = sentCount;
            return View(messages);
        }
      
        public ActionResult sentMessages()
        {
            var mail = (string)Session["currentMail"];
            var messages = context.Messages.Where(x => x.sender == mail).OrderByDescending(x => x.messageId).ToList();
            var sentCount = context.Messages.Count(x => x.sender == mail).ToString();
            ViewBag.sentCount = sentCount;
            var incomingCount = context.Messages.Count(x => x.receiver == mail).ToString();
            ViewBag.incomingCount = incomingCount;
            return View(messages);
        }
      
        public ActionResult detailMessage(int id)
        {
            var mail = (string)Session["currentMail"];
            var messageInfo = context.Messages.Where(x => x.messageId == id).ToList();
            var sentCount = context.Messages.Count(x => x.sender == mail).ToString();
            ViewBag.sentCount = sentCount;
            var incomingCount = context.Messages.Count(x => x.receiver == mail).ToString();
            ViewBag.incomingCount = incomingCount;
            return View(messageInfo);
        }
        
        public ActionResult detailMessage2(int id)
        {
            var mail = (string)Session["currentMail"];
            var messageInfo = context.Messages.Where(x => x.messageId == id).ToList();
            var sentCount = context.Messages.Count(x => x.sender == mail).ToString();
            ViewBag.sentCount = sentCount;
            var incomingCount = context.Messages.Count(x => x.receiver == mail).ToString();
            ViewBag.incomingCount = incomingCount;
            return View(messageInfo);
        }
        
        [HttpGet]
        public ActionResult newMessage()
        {

            var mail = (string)Session["currentMail"];
            var sentCount = context.Messages.Count(x => x.sender == mail).ToString();
            ViewBag.sentCount = sentCount;
            var incomingCount = context.Messages.Count(x => x.receiver == mail).ToString();
            ViewBag.incomingCount = incomingCount;
            return View();


        }
       
        [HttpPost]
        public ActionResult newMessage(Message m)
        {
            m.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var mail = (string)Session["currentMail"];
            m.sender = mail.ToString();
            context.Messages.Add(m);
            context.SaveChanges();
           
            return RedirectToAction("sentMessages");
        }
       
        public ActionResult cargoTracking(string p)
        {
            var cargoList = from x in context.CargoDetails select x;

           
                cargoList = cargoList.Where(y => y.trackingCode.Equals(p));
            

            return View(cargoList.ToList());
        
        }
       
        public ActionResult cargoTrackingDetail(string id)
        {
            var cargo = context.CargoTrackings.Where(x => x.trackingCode == id).ToList();
            return View(cargo);
        }
      
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["currentMail"];
            var id = context.Currents.Where(x=>x.currentMail==mail).Select(y=>y.currentId).FirstOrDefault();
            var current = context.Currents.Find(id);
            return PartialView("Partial1",current);
        }
        public PartialViewResult Partial2()
        {
            var values = context.Messages.Where(x => x.sender == "admin").ToList();
            return PartialView(values);
        }
        public ActionResult updateCurrentInfo(Current c)
        {
            var current = context.Currents.Find(c.currentId);
            current.currentName = c.currentName;
            current.currentSurname = c.currentSurname;
            current.password = c.password;
            current.currentCity = c.currentCity;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}