using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.RoleView
{
    internal class ListRoleView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Roles");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadLine();
            MenuRoleView.Load();


        }

        private static void List()
        {
            Repository<Role> roleRepository = new Repository<Role>();
            var roles = roleRepository.Get();
            foreach (var item in roles)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}