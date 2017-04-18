using System;
using System.Collections;
using System.Linq;
using Service.Interfaces.Entities;

namespace Service.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();
        IEnumerable Find(Func<TEntity, bool> f);
        void Create(TEntity e);
        void Delete(int id);
        void Update(TEntity e);
    }
}