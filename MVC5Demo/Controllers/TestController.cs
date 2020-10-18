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
        // GET: Test
        public ActionResult Index()
        {
            var data = new List<Person>() {
                new Person() { Id = 1, Name = "Will", Age = 18 },
                new Person() { Id = 2, Name = "Tom", Age = 28 },
                new Person() { Id = 3, Name = "Mary", Age = 38 },
                new Person() { Id = 4, Name = "John", Age = 48 },
            };

            return View(data);
        }
    }
}