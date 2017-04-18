using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using ORM;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace Service.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly DbContext context;
        private readonly IUnitOfWork uow;

        public CommentService(DbContext context, IUnitOfWork uow)
        {
            this.context = context;
            this.uow = uow;
        }

        public IQueryable<CommentEntity> GetAll()
        {
            return context.Set<Comment>().Select(com => new CommentEntity()
            {
                Id = com.Id,
                Name = com.Name,
                CreationDate = com.CreationDate,
                CreationTime = com.CreationTime,
                UserName = com.User.Login,
                NewId = com.NewsId
            });
        }

        public IEnumerable Find(Func<CommentEntity, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(CommentEntity e)
        {
            context.Set<Comment>().Add(new Comment()
            {
                Name = e.Name,
                CreationDate = e.CreationDate,
                CreationTime = e.CreationTime,
                NewsId = e.NewId,
                UserId = e.UserId
            });
            uow.Commit();
        }

        public void Delete(int id)
        {
            var comment = context.Set<Comment>().FirstOrDefault(x => x.Id == id);
            context.Set<Comment>().Remove(comment);
            uow.Commit();
        }

        public void Update(CommentEntity e)
        {
            throw new NotImplementedException();
        }
    }
}