using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class ProductController : BaseController
    {
        ProductService app = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.UnitList = MyApp.Functions.Functions.getUnitJSON();
            return View();
        }
    }
}