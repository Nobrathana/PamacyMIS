using MyApp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class BaseController : Controller
    {
        public static string CurrentLanguage { get; set; }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            //get Config Data into Cache
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                CurrentLanguage = lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    CurrentLanguage = lang = userLang;
                }
                else
                {
                    CurrentLanguage = lang = LanguageManager.GetDefaultLanguage();
                }
            }
            new LanguageManager().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageManager().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ToggleLanguage()
        {
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                CurrentLanguage = lang = langCookie.Value;
            }
            new LanguageManager().SetLanguage(lang == "km" ? "en-GB" : "km");
            return Redirect(Request.UrlReferrer.ToString());
        }

        public JsonResult GetCurrentLanguage()
        {
            var resources = typeof(Resource);
            return Json(new
            {
                lang = CurrentLanguage,
                resources = resources
            }, JsonRequestBehavior.AllowGet);
        }

    }
}