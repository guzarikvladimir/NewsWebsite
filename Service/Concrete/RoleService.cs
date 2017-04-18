using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using ORM;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace Service.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly DbContext context;

        public RoleService(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<RoleEntity> GetAll()
        {
            return context.Set<Role>().Select(role => new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        public IEnumerable Find(Func<RoleEntity, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(RoleEntity e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleEntity e)
        {
            throw new NotImplementedException();
        }
    }
}