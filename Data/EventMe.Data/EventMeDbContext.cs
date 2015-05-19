namespace EventMe.Data
{
    using System.Data.Entity;

    using EventMe.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventMeDbContext : IdentityDbContext<ApplicationUser>, IEventMeDbContext
    {
        public EventMeDbContext()
            : base("name=EventMeDbContext", false)
        {
        }

        public virtual IDbSet<Country> Countries{ get; set; }

        public virtual IDbSet<Town> Towns { get; set; }
        
        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<EventComment> EventComments { get; set; }

        public virtual IDbSet<EventGallery> EventGalleries { get; set; }

        public virtual IDbSet<GalleryPhoto> GalleryPhotos { get; set; }

        public virtual IDbSet<PersonalMessage> PersonalMessages { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public static EventMeDbContext Create()
        {
            return new EventMeDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
