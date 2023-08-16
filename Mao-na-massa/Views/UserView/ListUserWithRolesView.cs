using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.UserView
{
    internal class ListUserWithRolesView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários com Roles");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadLine();
            MenuUserView.Load();

        }

        private static void List()
        {
            UserRepository userRepository = new UserRepository();
            var users = userRepository.GetWithRoles();
            foreach (var item in users)
            {
                foreach(var role in item.Roles)
                {
                    Console.WriteLine($"{item.ToString()} - {role.ToString()}");
                }
            }
        }
    }
}