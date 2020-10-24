using MVC5Demo.Models;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
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

            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.FirstName), "ID", "FirstName");

            return View(department);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var dept = db.Department.Find(id);

            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.FirstName), "ID", "FirstName", dept.InstructorID);

            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(int id, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);

                item.InjectFrom(department);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var dept = db.Department.Find(id);

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);

            return View(dept);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dept = db.Department.Find(id);

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dept = db.Department.Find(id);

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var dept = db.Department.Find(id);

            db.Department.Remove(dept);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}