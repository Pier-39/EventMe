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

        IRepository<EventGallery> EventGalleries { get; }

        IRepository<GalleryPhoto> GalleryPhotos { get; }

        IRepository<Country> Countries { get; }

        IRepository<Town> Towns { get; }

        IRepository<PersonalMessage> PersonalMessages { get; }

        IUserStore<ApplicationUser> UserStore { get; }

        int SaveChanges();
    }
}
