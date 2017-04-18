using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ORM;
using Service.Interfaces.Entities;
using Service.Interfaces.Services;

namespace Service.Concrete
{
    public class NewsService : INewsService
    {
        private readonly DbContext context;
        private readonly IUnitOfWork uow;

        public NewsService(DbContext context, IUnitOfWork uow)
        {
            this.context = context;
            this.uow = uow;
        }

        public IQueryable<NewsEntity> GetAll()
        {
            return context.Set<News>().Select(n => new NewsEntity()
            {
                Id = n.Id,
                Name = n.Name,
                Description = n.Description,
                CreationDate = n.CreationDate,
                CreationTime = n.CreationTime,
                CategoryId = n.CategoryId,
                ImageData = n.ImageData,
                ImageMimeType = n.ImageMimeType,
                Category = n.Category.Name,
                Comments = n.Comments.OrderByDescending(com => com.CreationDate)
                    .ThenByDescending(com => com.CreationTime)
                    .Select(com => new CommentEntity()
                {
                    Id = com.Id,
                    Name = com.Name,
                    CreationDate = com.CreationDate,
                    CreationTime = com.CreationTime,
                    UserName = com.User.Login,
                    NewId = com.NewsId
                }).ToList()
            });
        }

        public IEnumerable Find(Func<NewsEntity, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(NewsEntity e)
        {
            context.Set<News>().Add(new News()
            {
                Name = e.Name,
                Description = e.Description,
                CreationDate = DateTime.Now.Date,
                CreationTime = DateTime.Now.TimeOfDay,
                CategoryId = e.CategoryId,
                ImageData = e.ImageData,
                ImageMimeType = e.ImageMimeType
            });
            uow.Commit();
        }

        public void Delete(int id)
        {
            var news = context.Set<News>().FirstOrDefault(n => n.Id == id);
            context.Set<News>().Remove(news);
            uow.Commit();
        }

        public void Update(NewsEntity e)
        {
            var user = context.Set<News>().FirstOrDefault(u => u.Id == e.Id);
            user.Name = e.Name;
            user.Description = e.Description;
            user.CategoryId = e.CategoryId;
            if (e.ImageData != null)
            {
                user.ImageMimeType = e.ImageMimeType;
                user.ImageData = e.ImageData;
            }
            uow.Commit();
        }
    }
}