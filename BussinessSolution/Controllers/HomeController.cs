using DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BussinessSolution.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILoginService _loginservice;

        public HomeController(ILoginService loginService)
        {
            this._loginservice = loginService;
        }

        public ActionResult Index()
        {
            var result = _loginservice.Login("test@gmail.com", "b");
            if (result == null)
            {
                return View();

            }
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}