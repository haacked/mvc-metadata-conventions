using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using ModelMetadataDemo.Web.Models;

namespace ModelMetadataDemo.Web.Controllers {
    public class HomeController : Controller {
        protected override void Initialize(RequestContext requestContext) {

            base.Initialize(requestContext);
        }

        public ActionResult Index(string culture) {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            SetCulture(culture);
            return View(new Character());
        }

        private void SetCulture(string culture) {
            culture = culture ?? "en";
            ViewBag.Culture = culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        }

        [HttpPost]
        public ActionResult Index(Character character, string culture) {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            SetCulture(culture);
            return View(character);
        }

        public ActionResult About() {
            return View();
        }
    }
}
