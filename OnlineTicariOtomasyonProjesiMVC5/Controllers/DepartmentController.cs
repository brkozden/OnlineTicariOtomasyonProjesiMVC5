using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonProjesiMVC5.Models.Classes;
namespace OnlineTicariOtomasyonProjesiMVC5.Controllers
{
    [Authorize(Roles = "A")]
    public class DepartmentController : Controller
    {
        // GET: Department

        Context context = new Context();
        public ActionResult Index()
        {
            var value = context.Departments.Where(x => x.Status == true).ToList();
            return View(value);
        }
     
        [HttpGet]
        public ActionResult addDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult removeDepartment(int id)
        {
            var depValue = context.Departments.Find(id);
            depValue.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult bringDepartment(int id)
        {
            var department = context.Departments.Find(id);
            return View("bringDepartment", department);
        }

        public ActionResult updateDepartment(Department department)
        {
            var depValue = context.Departments.Find(department.departmentId);
            depValue.departmentName = department.departmentName;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult detailDepartment(int id)
        {

            var empValue = context.Employees.Where(x => x.departmentId == id).ToList();

            var dptName = context.Departments.Where(x => x.departmentId == id).Select(x => x.departmentName).FirstOrDefault();
            ViewBag.dpt = dptName;
            return View(empValue);
        }

        public ActionResult saleDepartmentEmployee(int id)
        {
            var values = context.SaleTransactions.Where(x => x.employeeId == id).ToList();
            var perNameSurname = context.Employees.Where(x => x.employeeId == id).Select(x => x.employeeName + " " + x.employeeSurname).FirstOrDefault();
            ViewBag.pns = perNameSurname;
            return View(values);
        }

    }
}