﻿namespace EventMe.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IEventMeDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
