namespace EventMe.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using EventMe.Data.Repositories;
    using EventMe.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventMeData : IEventMeData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<ApplicationUser> userStore;

        public EventMeData()
            : this(new EventMeDbContext())
        {
            
        }

        public EventMeData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Event> Events
        {
            get
            {
                return this.GetRepository<Event>();
            }
        }

        public IRepository<EventComment> EventComments
        {
            get
            {
                return this.GetRepository<EventComment>();
            }
        }

        public IRepository<EventGallery> EventGalleries
        {
            get
            {
                return this.GetRepository<EventGallery>();
            }
        }

        public IRepository<GalleryPhoto> GalleryPhotos
        {
            get
            {
                return this.GetRepository<GalleryPhoto>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
            }
        }

        public IRepository<PersonalMessage> PersonalMessages
        {
            get
            {
                return this.GetRepository<PersonalMessage>();
            }
        }

        public IUserStore<ApplicationUser> UserStore
        {
            get
            {
                return this.userStore ?? (this.userStore = new UserStore<ApplicationUser>(this.dbContext));
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
