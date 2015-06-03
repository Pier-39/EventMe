namespace EventMe.Data.UnitOfWork
{
    using EventMe.Data.Repositories;
    using EventMe.Models;

    using Microsoft.AspNet.Identity;

    public interface IEventMeData
    {
        IRepository<ApplicationUser> Users { get; }
        
        IRepository<Event> Events { get; }

        IRepository<EventComment> EventComments { get; }

        IRepository<Country> Countries { get; }

        IRepository<EventType> EventTypes { get; }

        IRepository<EventStatus> EventStatuses { get; }

        IRepository<MessageStatus> MessageStatuses { get; }

        IRepository<Town> Towns { get; }

        IRepository<PersonalMessage> PersonalMessages { get; }

        IUserStore<ApplicationUser> UserStore { get; }

        int SaveChanges();
    }
}
