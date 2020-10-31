using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MVC5Demo.Controllers
{
    //[Authorize(Roles = "admin,manager", Users = "will,john")]
    [Authorize]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid && ValidateUser(login))
            {
                FormsAuthentication.RedirectFromLoginPage(login.Username, false);
                return Content("");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private bool ValidateUser(LoginVM login)
        {
            return login.Username == "will";
        }
    }
}