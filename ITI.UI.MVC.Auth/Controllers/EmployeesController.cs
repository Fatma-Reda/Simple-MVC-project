using ITI.UI.MVC.Auth.Models.Entities;
using ITI.UI.MVC.Auth.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using ITI.UI.MVC.Auth.Models;

namespace ITI.UI.MVC.Auth.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        static ApplicationDbContext context = new ApplicationDbContext();
        // static ModelContext context = new ModelContext();
        // GET: Employees
        
        public ActionResult Index()
        {
            EmployeeViewModel empVM = new EmployeeViewModel();
            empVM.Employees = context.Employees.Include(e => e.Department).ToList();
            empVM.Departments = context.Departments.ToList();
            return View(empVM);
        }

        public ActionResult Details(int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Add(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(emp.Employee);
                context.SaveChanges();
                return PartialView("_PartialEmployeeRow",emp);
            }
            EmployeeViewModel empVM = new EmployeeViewModel();
            empVM.Departments = context.Departments.ToList();
            return View("AddEdit", empVM);
        }

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            Employee emp= context.Employees.FirstOrDefault(e => e.Id==id);
            if (emp != null)
            {
                ViewBag.Action = "Edit";
                EmployeeViewModel employeeVM = new EmployeeViewModel();
                employeeVM.Employee = emp;
                employeeVM.Departments = context.Departments.ToList();
                return View("AddEdit", employeeVM);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit( EmployeeViewModel empVM)
        {
            if (ModelState.IsValid)
            {
                Employee oldemp = context.Employees.FirstOrDefault(e => e.Id == empVM.Employee.Id);
                if (oldemp!=null)
                {
                    oldemp.Name = empVM.Employee.Name;
                    oldemp.Age = empVM.Employee.Age;
                    oldemp.Gender = empVM.Employee.Gender;
                    oldemp.Email = empVM.Employee.Email;
                    oldemp.FK_depId = empVM.Employee.FK_depId;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            EmployeeViewModel emp = new EmployeeViewModel();
            emp.Employee = empVM.Employee;
            emp.Departments = context.Departments.ToList();
            return View("AddEdit", empVM);
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<bool> Delete(int id)
        {
            Employee res = context.Employees.FirstOrDefault(e => e.Id == id);
            if (res != null)
            {
                context.Employees.Remove(res);
                await context.SaveChangesAsync();
                return true;
            }
            //return RedirectToAction("Index");
            return false;
        }
       
    }
}