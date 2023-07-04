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
 
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context context = new Context();
        public ActionResult Index( int page = 1)
        {
            var employeeList = context.Employees.ToList().ToPagedList(page, 10); 
            return View(employeeList);
        }
        [HttpGet]
        public ActionResult addEmployee()
        {
            List<SelectListItem> values = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmentName,
                                               Value = x.departmentId.ToString()
                                           }).ToList();

            ViewBag.empDep = values;
            return View();
        }
        [HttpPost]
        public ActionResult addEmployee(Employee e)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "/Image/Employees/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                e.employeeImage = "/Image/Employees/" + fileName + extension;
            }
            context.Employees.Add(e);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult bringEmployee(int id)
        {
            var employee = context.Employees.Find(id);

            List<SelectListItem> departmentList = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmentName,
                                               Value = x.departmentId.ToString()
                                           }).ToList();

            ViewBag.departmenList = departmentList;
            return View("bringEmployee",employee);
        }
        public ActionResult updateEmployee(Employee e)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "/Image/Employees/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                e.employeeImage = "/Image/Employees/" + fileName + extension;
            }
            var employee = context.Employees.Find(e.employeeId);
            employee.employeeName = e.employeeName;
            employee.employeeSurname = e.employeeSurname;
            employee.employeeImage = e.employeeImage;
            employee.departmentId = e.departmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    
    }
}