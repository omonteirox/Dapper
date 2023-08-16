using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.RoleView
{
    internal class DeleteRoleView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de Roles");
            Console.WriteLine("-------------------------");
            Delete();
            Console.ReadLine();
            MenuRoleView.Load();

        }

        private static void Delete()
        {
            Repository<Role> roleRepository = new Repository<Role>();
            Console.WriteLine("Digite o Id da Role que deseja excluir:");
            var id = Console.ReadLine();
            var role = roleRepository.GetById(Convert.ToInt32(id));
            if (role != null)
            {
                roleRepository.Delete(role.Id);
                Console.WriteLine("Role excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Role não encontrada!");
            }
        }
    }
}