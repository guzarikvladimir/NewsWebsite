using System.Data.Entity;
using Service.Interfaces.Services;

namespace Service.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context?.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
