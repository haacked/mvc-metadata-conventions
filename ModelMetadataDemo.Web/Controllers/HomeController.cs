using System.Web.Mvc;
using ModelMetadataDemo.Web.Models;

namespace ModelMetadataDemo.Web.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(new Character());
        }

        [HttpPost]
        public ActionResult Index(Character character) {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(character);
        }

        public ActionResult About() {
            return View();
        }
    }
}
