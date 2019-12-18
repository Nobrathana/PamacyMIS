using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Modules;
using System.Data;
using MyApp.Entity;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers
{
    [Authorize]
    public class RoleController : BaseController
    {
        private MADBEntities db = new MADBEntities();
        private IRepository<RoleViewModels> roleService;
        // GET: Role
        public ActionResult Index()
        {
            var list = db.tb_Role_Permission.ToList();
            ViewBag.List = list;
            Functions.CodeGenerate.FLPassword();
            return View();
        }

        public ActionResult Create()
        {
            return View(new RoleViewModels());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleViewModels model)
        {
            try
            {
                roleService = new RoleService();
                roleService.Add(model);
                ViewBag.MsgSuccess = "Save has been successfully.";
                return View("Index");
            }
            catch(Exception ex)
            {
                Modules.AppLogger.writeLog(model.ToString(), ex.Message);
                return View(model);
            }
        }
    }
}