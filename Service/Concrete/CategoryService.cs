using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using ORM;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly DbContext context;
        private readonly IUnitOfWork uow;

        public CategoryService(DbContext context, IUnitOfWork uow)
        {
            this.context = context;
            this.uow = uow;
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            return context.Set<Category>().Select(c => new CategoryEntity()
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public IEnumerable Find(Func<CategoryEntity, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(CategoryEntity e)
        {
            context.Set<Category>().Add(new Category()
            {
                Name = e.Name
            });
            uow.Commit();
        }

        public void Delete(int id)
        {
            var category = context.Set<Category>().FirstOrDefault(c => c.Id == id);
            context.Set<Category>().Remove(category);
            uow.Commit();
        }

        public void Update(CategoryEntity e)
        {
            throw new NotImplementedException();
        }
    }
}