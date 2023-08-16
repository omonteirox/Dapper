using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.UserView
{
    internal class DeleteUserView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Usuário");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o Id do usuário que deseja excluir");
            var id = int.Parse(Console.ReadLine()!);
            Delete(id);
        }

        private static void Delete(int id)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Delete(id);
            Console.WriteLine("Usuário excluído com sucesso!");
            Console.ReadLine();
            MenuUserView.Load();
        }
    }
}