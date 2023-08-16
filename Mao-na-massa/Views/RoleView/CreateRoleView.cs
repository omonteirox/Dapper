using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.RoleView
{
    internal class CreateRoleView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine(" --- Cadastrar novo perfil --- \n");
            Console.WriteLine("Digite o nome do perfil:");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o slug do perfil:");
            var slug = Console.ReadLine();
            var role = new Role();
            role.Name = name;
            role.Slug = slug;    
            Create(role);

        }
        internal static void Create(Role role) {
            Repository<Role> repository = new Repository<Role>();
            repository.Create(role);
            Console.WriteLine("Perfil cadastrado com sucesso!");
            Console.ReadLine();
            MenuRoleView.Load();
        }
    }
}