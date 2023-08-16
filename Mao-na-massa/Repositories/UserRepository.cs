

using Dapper;
using MaoNaMassa.Models;
using Microsoft.Data.SqlClient;

namespace MaoNaMassa.Repositories
{
    public class UserRepository : Repository<User>
    {
       public void AddRole(int userId, int roleId)
        {
            UserRepository userRepository = new UserRepository();
            var user = userRepository.GetById(userId);
            Repository<Role> roleRepository = new Repository<Role>();
            var role = roleRepository.GetById(roleId);
            var query = @"INSERT INTO [UserRole] ([UserId], [RoleId]) VALUES (@UserId, @RoleId)";
            Database.Connection.Execute(query, new { UserId = user.Id, RoleId = role.Id });
        }
        public List<User> GetWithRoles()
        {
            var query = @"
                        SELECT [User].*, [Role].*
                        
                        FROM [User]
                        
                        LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                        LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";
            var users = new List<User>();
            var items = Database.Connection.Query<User, Role, User>(query, (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if (role !=null)
                    {
                    usr.Roles.Add(role);
                    }
                    users.Add(usr);
                }
                else
                    usr.Roles.Add(role);

                return user;
            }, splitOn: "Id");
            return users;
        }
    }
}
