using HelpMap.Domain.Interfaces;
using HelpMap.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HelpMap.Domain.Models;

namespace HelpMap.Infrastructure.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ContextEntity Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(ContextEntity context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual TEntity GetByName(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void UpDate(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public TEntity GetByName(string nomeGrupo)
        {
            throw new NotImplementedException();
        }
    }
}