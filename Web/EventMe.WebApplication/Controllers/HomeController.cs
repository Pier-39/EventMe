using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EventMe.Data.UnitOfWork;

namespace EventMe.WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEventMeData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
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

        [HttpGet]
        public ActionResult NotFound()
        {
            ViewBag.Message = "Sory, this page doesn't exist!";
            return this.View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            ViewBag.Message = "Ooops, sorry something went wrong!";
            return this.View();
        }
    }

}