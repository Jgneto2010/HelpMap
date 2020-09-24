using HelpMap.Domain.Models;
using System;
using System.Collections.Generic;

namespace HelpMap.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void UpDate(TEntity obj);
        void Remove(int id);
        int SaveChanges();
        TEntity GetByName(string nomeGrupo);

    }
}
