using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.UserView
{
    internal class ListUserView
    {
        
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadLine();
            MenuUserView.Load();
        }
        internal static void List()
        {
            UserRepository userRepository = new UserRepository();
            var users = userRepository.Get();
            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}