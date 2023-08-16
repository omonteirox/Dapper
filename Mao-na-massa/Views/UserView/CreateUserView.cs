using MaoNaMassa.Models;
using MaoNaMassa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MaoNaMassa.Views.UserView
{
    internal class CreateUserView
    {
       

        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Usuário");
            Console.WriteLine("-------------------------");
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
            
            var user = new User();
            user.Name = name;
            user.Email = email;
            user.PasswordHash = password;
            user.Bio = bio;
            user.Image = url;
            user.Slug = slug;

            Save(user);
        }
        internal static void Save(User user)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Create(user);
            Console.WriteLine("Usuário cadastrado com sucesso!");
            Console.ReadLine();
            MenuUserView.Load();
        }
    }
}


//public int Id { get; set; }
//public string Name { get; set; }
//public string Email { get; set; }
//public string PasswordHash { get; set; }
//public string Bio { get; set; }
//public string Image { get; set; }
//public string Slug { get; set; }