using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.UserView
{
    internal class AddRoleToUserView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular Usuário a uma Role");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o Id do usuário que deseja vincular a uma role");
            var userId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o Id da role que deseja vincular ao usuário");
            var roleId = int.Parse(Console.ReadLine()!);
            Add(userId, roleId);
            Console.WriteLine("Usuário e role vinculados com sucesso!");
            Console.ReadLine();
            MenuUserView.Load();

        }

        private static void Add(int userId, int roleId)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.AddRole(userId, roleId);

        }
    }
}