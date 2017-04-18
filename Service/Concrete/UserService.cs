using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using ORM;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly DbContext context;
        private readonly IUnitOfWork uow;

        public UserService(DbContext context, IUnitOfWork uow)
        {
            this.context = context;
            this.uow = uow;
        }

        public IQueryable<UserEntity> GetAll()
        {
            return context.Set<User>().Select(user => new UserEntity()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = user.Role.Name
            });
        }

        public IEnumerable Find(Func<UserEntity, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(UserEntity e)
        {
            context.Set<User>().Add(new User()
            {
                Login = e.Login,
                Password = e.Password,
                RoleId = e.RoleId
            });
            uow.Commit();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserEntity e)
        {
            throw new NotImplementedException();
        }
    }
}