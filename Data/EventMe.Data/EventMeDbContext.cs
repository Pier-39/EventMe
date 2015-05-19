namespace EventMe.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using EventMe.Models;
    using EventMe.Data.Migrations;

    public class EventMeDbContext : IdentityDbContext<ApplicationUser>, IEventMeDbContext
    {
        public EventMeDbContext()
            : base("name=EventMeDbContext", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventMeDbContext, Configuration>());
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
