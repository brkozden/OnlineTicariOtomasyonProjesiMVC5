using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
   
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator makeCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode barcode = makeCode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap img = barcode.GetGraphic(100))
                {
                    img.Save(ms, ImageFormat.Png);
                    ViewBag.barcodeImg = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}