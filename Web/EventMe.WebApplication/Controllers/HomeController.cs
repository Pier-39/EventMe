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

        [HttpGet]
        public ActionResult Index()
        {
            // redirect user to dashboard if logged 
            if (this.UserProfile != null)
            {
                return this.RedirectToAction("Dashboard", "Home");
            }

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Dashboard()
        {
            var currentUser = this.UserProfile;
            ViewBag.CurrentUser = currentUser;

            //TODO return events in a paged list model to the view
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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