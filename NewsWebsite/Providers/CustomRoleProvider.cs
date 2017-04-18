using System.Linq;
using System.Web.Security;
using Service.Interfaces.Services;

namespace NewsWebsite.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
           => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = UserService.GetAll().FirstOrDefault(u => u.Login == username);

            if (user == null) return false;

            return user.Role == roleName;
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = UserService.GetAll().FirstOrDefault(u => u.Login == username);

            return user == null ? null : new[] {user.Role};
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}