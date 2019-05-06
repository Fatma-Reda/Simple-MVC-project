using ITI.UI.MVC.Auth.Models;
using ITI.UI.MVC.Auth.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.Auth.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    public class DepartmentsController : Controller
    {
        static ApplicationDbContext context = new ApplicationDbContext();
         // ModelContext context = new ModelContext();
        // GET: Departments
        public ActionResult Index()
        {
           var deps= context.Departments.ToList();
            return View(deps);
        }
        public ActionResult Details(int id)
        {
            Department dep = context.Departments.FirstOrDefault(d => d.Id == id);
            return View(dep);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(Department dep)
        {

            if (ModelState.IsValid)
            {
                context.Departments.Add(dep);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddEdit");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Department dep= context.Departments.FirstOrDefault(d => d.Id == id);
            if (dep != null)
            {
                ViewBag.Action = "Edit";
                return View("AddEdit", dep);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Department dep)
        {
            if (ModelState.IsValid)
            {
                var olddep = context.Departments.FirstOrDefault(d => d.Id == dep.Id);
                if (olddep != null)
                {
                    olddep.Name = dep.Name;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("AddEdit", dep);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var dep = context.Departments.FirstOrDefault(d => d.Id == id);
            if (dep != null)
            {
                context.Departments.Remove(dep);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}