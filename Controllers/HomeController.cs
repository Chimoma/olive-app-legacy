using System.Web.Mvc;

namespace OliveApp.Legacy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Olive & Olive Client Portal (Legacy)";
            return View();
        }
    }
}
