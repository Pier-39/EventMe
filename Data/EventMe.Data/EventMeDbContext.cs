namespace EventMe.Data
{
    using System.Data.Entity;

    using EventMe.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventMeDbContext : IdentityDbContext<ApplicationUser>
    {
        public EventMeDbContext()
            : base("name=EventMeDbContext", false)
        {
        }

        public virtual IDbSet<Event> Events { get; set; }

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
