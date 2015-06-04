namespace EventMe.WebApplication.Controllers
{
    using System.Linq;

    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using EventMe.Data.UnitOfWork;
    using EventMe.Models;
    using EventMe.WebApplication.InputModels;
    using EventMe.WebApplication.ViewModels;

    using PagedList;

    public class EventsController : BaseController
    {
        public EventsController(IEventMeData data) 
            : base(data)
        {
            
        }

        // GET: Events
        public ActionResult Index(int? page = 1)
        {
            const int PageSize = 3;
            int pageNumber = (page ?? 1);

            var events = this.Data.Events.
                All().
                OrderByDescending(x => x.Date).
                ThenByDescending(x => x.Id).
                Select(EventViewModel.ViewModel);
           
            return this.View(events.ToPagedList(pageNumber, PageSize));
        }

        // GET: Events/5/Details
        public ActionResult Details(int id)
        {
            var eventEntity =
            this.Data.Events.All().Select(EventViewModel.ViewModel).FirstOrDefault(x => x.Id == id);

            return this.View(eventEntity);
        }

        // GET: Events/Add
        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        // POST: Events/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(EventInputModel model)
        {
            try
            {
                var eventEntity = new Event
                                  {
                                      Title = model.Title,
                                      Description = model.Description,
                                      Date = model.Date,
                                      FieldType = model.FieldType,
                                      OrganizerId = this.UserProfile.Id,
                                      RatedStars = 0,
                                      PhotoUrl = model.PhotoUrl
                                  };

                this.Data.Events.Add(eventEntity);
                this.Data.SaveChanges();

                return this.RedirectToAction(c => c.Details(eventEntity.Id));
            }
            catch
            {
                return this.View();
            }
        }    

        public ActionResult Attend(int id)
        {
            var eventEntity = this.Data.Events.All().FirstOrDefault(x => x.Id == id);

            if (eventEntity.AttendingUsers.Count < eventEntity.MaxAttendantsAllowed)
            {
                eventEntity.AttendingUsers.Add(this.UserProfile);

                this.Data.SaveChanges();
            }

            return this.RedirectToAction(c => c.Details(id));
        }
    }
}
