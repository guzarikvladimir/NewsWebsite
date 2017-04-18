using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using ORM;
using Service.Concrete;
using Service.Interfaces.Services;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        public static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<Newswebsitedb>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<Newswebsitedb>().InSingletonScope();
            }

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<INewsService>().To<NewsService>();
        }
    }
}
