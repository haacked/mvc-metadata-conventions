using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using ModelMetadataDemo.Web.Models;

namespace ModelMetadataDemo.Web.Controllers {
    public class HomeController : Controller {
        protected override void Initialize(RequestContext requestContext) {
            var culture = requestContext.HttpContext.Request.QueryString["culture"];
            if (!String.IsNullOrEmpty(culture)) {
                SetCulture(culture);
            }
            base.Initialize(requestContext);
        }

        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View(new Character());
        }

        private void SetCulture(string culture) {
            culture = culture ?? "en";
            ViewBag.Culture = culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
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
