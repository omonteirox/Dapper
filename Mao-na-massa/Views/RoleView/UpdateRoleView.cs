using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.RoleView
{
    internal class UpdateRoleView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualização de Roles");
            Console.WriteLine("-------------------------");
            Update();
            Console.ReadLine();
            MenuRoleView.Load();

        }

        private static void Update()
        {
            Repository<Role> repository = new Repository<Role>();   
            Console.WriteLine("Digite o Id da Role que deseja atualizar:");
            var id = Console.ReadLine();
            var role = repository.GetById(Convert.ToInt32(id));
            if (role != null)
            {
                Console.WriteLine("Digite o nome da Role:");
                role.Name = Console.ReadLine();
                Console.WriteLine("Digite o Slug da Role:");
                role.Slug = Console.ReadLine();
                repository.Update(role);
                Console.WriteLine("Role atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Role não encontrada!");
            }   
        }
    }
}