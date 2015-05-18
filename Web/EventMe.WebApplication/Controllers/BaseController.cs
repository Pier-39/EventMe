namespace EventMe.WebApplication.Controllers
{
    using System.Web.Mvc;

    using EventMe.Data.UnitOfWork;

    public abstract class BaseController : Controller
    {
        protected BaseController(IEventMeData data)
        {
            this.Data = data;
        }

        protected BaseController()
            : this(new EventMeData())
        {
        }

        protected IEventMeData Data { get; private set; }
    }
}