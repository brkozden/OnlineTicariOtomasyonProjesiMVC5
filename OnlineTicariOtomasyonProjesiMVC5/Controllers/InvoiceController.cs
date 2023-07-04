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
  
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index(int page=1)
        {
            var invoiceList = context.Invoices.ToList().ToPagedList(page, 10);
            return View(invoiceList);
        }
        [HttpGet]
        public ActionResult addInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addInvoice(Invoice i)
        {
            context.Invoices.Add(i);
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult bringInvoice(int id)
        {
            var invoice = context.Invoices.Find(id);

            return View("bringInvoice",invoice);
        }
        public ActionResult updateInvoice(Invoice i)
        {
            var invoice = context.Invoices.Find(i.invoiceId);
            invoice.invoiceSerialNo = i.invoiceSerialNo;
            invoice.invoiceSequenceNo = i.invoiceSequenceNo;
            invoice.taxOffice = i.taxOffice;
            invoice.Date = i.Date;
            invoice.Hour = i.Hour;
            invoice.consigner = i.consigner;
            invoice.recipient = i.recipient;
            context.SaveChanges();

           return RedirectToAction("Index");

        }
        public ActionResult detailInvoice(int id)
        {
            var values = context.InvoicePencils.Where(x => x.invoiceId == id).ToList();
            var invoiceNo = context.Invoices.Where(x => x.invoiceId == id).Select(y => y.invoiceSerialNo + " - " + y.invoiceSequenceNo).FirstOrDefault();
            ViewBag.invoiceNo = invoiceNo;
            var invoiceId = context.Invoices.Where(x => x.invoiceId == id).Select(y => y.invoiceId).FirstOrDefault();
            ViewBag.invoiceId = invoiceId;
            return View(values);
        }
        [HttpGet]
        public ActionResult newPencil(int id)
        {
            var invoiceId = context.Invoices.Where(x => x.invoiceId == id).Select(y => y.invoiceId).FirstOrDefault();
            ViewBag.invoiceId = invoiceId;
            return View();

        }
        [HttpPost]
        public ActionResult newPencil(InvoicePencil invoicePencil)
        {
           
            context.InvoicePencils.Add(invoicePencil);
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}