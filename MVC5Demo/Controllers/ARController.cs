using Antlr.Runtime.Misc;
using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class ARController : Controller
    {
        DepartmentRepository repo;

        public ARController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTest2()
        {
            return View("Index");
        }

        public ActionResult ViewTest3()
        {
            return View("TEMP");
        }

        public ActionResult ViewTest4()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            return Content("<root>123</root>", "text/xml", Encoding.GetEncoding("big5"));
        }

        public ActionResult FileTest(bool dl = false)
        {
            if (dl)
            {
                return File(Server.MapPath("~/Content/download.jpg"), "image/jpeg", "MyAA.jpg");
            }
            else
            {
                return File(Server.MapPath("~/Content/download.jpg"), "image/jpeg");
            }
        }

        public ActionResult JsonTest()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;

            var data = repo.Get單一筆部門資料(1);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JsonTest2()
        {
            //repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;

            var data = repo.Get單一筆部門資料(1);

            return Json(data);
        }

    }
}