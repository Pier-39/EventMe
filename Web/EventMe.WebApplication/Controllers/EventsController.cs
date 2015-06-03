using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

namespace EventMe.WebApplication.Controllers
{
    using System.Data.Entity;

    using EventMe.Data.UnitOfWork;
    using EventMe.WebApplication.ViewModels;

    using Microsoft.Ajax.Utilities;

    using WebGrease.Css.Extensions;

    public class EventsController : BaseController
    {
        public EventsController(IEventMeData data) 
            : base(data)
        {
            
        }

        // GET: Events
        public ActionResult Index()
        {
            var events = this.Data.Events.All().Select(EventViewModel.ViewModel);

            return this.View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            var eventEntity =
            this.Data.Events.All().Select(EventViewModel.ViewModel).FirstOrDefault();

            return this.View(eventEntity);
        }

        // GET: Events/Create
        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        // POST: Events/Create
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return this.RedirectToAction(c => c.Index());
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return this.RedirectToAction(c => c.Index());
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EventMe(int? id)
        {
            return this.Content("Successfully Evented for " + id);
        }
    }
}
