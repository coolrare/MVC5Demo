using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class VTController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.data = new int[] { 1, 2, 3, 4, 5 };

            return PartialView();
        }
    }
}