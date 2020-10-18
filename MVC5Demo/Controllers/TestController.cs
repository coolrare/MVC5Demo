using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class TestController : Controller
    {
        static List<Person> data = new List<Person>() {
                new Person() { Id = 1, Name = "Will", Age = 18 },
                new Person() { Id = 2, Name = "Tom", Age = 28 },
                new Person() { Id = 3, Name = "Mary", Age = 38 },
                new Person() { Id = 4, Name = "John", Age = 48 },
            };

        // GET: Test
        public ActionResult Index()
        {
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                data.Add(person);

                return RedirectToAction("Index");
            }

            return View(person);
        }
    }
}