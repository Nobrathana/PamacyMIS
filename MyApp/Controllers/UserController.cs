using MyApp.Models;
using MyApp.Modules;
using MyApp.Services;
using System;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private UserService app = new UserService();
        public ActionResult Index()
        {
            ViewBag.List = app.List;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Register(UserViewModels model)
        {
            if (!ModelState.IsValid) { return null; }
            try
            {
                app.Add(model);
                return Json(new SweetAlert2Helper("0001", SweetAlertType.success), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                Modules.AppLogger.writeLog(model.ToString(), ex.Message);
                return Json(new SweetAlert2Helper("There was a problem!", ex.Message, "warning"), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangeNewPassword model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                app.ChangePassword(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Modules.AppLogger.writeLog(model.ToString(), ex.Message);
                return View(model);
            }
           
        }
    }
}