using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.UserView
{
    internal class UpdateUserView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Usuário");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o Id do usuário que deseja atualizar");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o nome do usuário");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o e-mail do usuário");
            var email = Console.ReadLine();
            Console.WriteLine("Digite a senha do usuário");
            var password = Console.ReadLine();
            Console.WriteLine("Digite a Biografia do usuário");
            var bio = Console.ReadLine();
            Console.WriteLine("Digite o url da Imagem do usuário");
            var url = Console.ReadLine();
            Console.WriteLine("Digite o Slug do usuário");
            var slug = Console.ReadLine();
            User usr = new User();
            usr.Id = id;
            usr.Name = name;
            usr.Email = email;
            usr.PasswordHash = password;
            usr.Bio = bio;
            usr.Image = url;
            usr.Slug = slug;
            Update(usr);
            Console.WriteLine("Usuário atualizado com sucesso");
            Console.ReadLine();
            MenuUserView.Load();
        }

        private static void Update(User usr)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Update(usr);
        }
    }
}