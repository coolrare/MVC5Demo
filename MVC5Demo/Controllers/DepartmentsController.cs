using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Department);
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(department);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            return View(department);
        }
    }
}