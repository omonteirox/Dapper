using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaoNaMassa.Views.UserView
{
    public class MenuUserView
    {
        // referencia outras classes
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Usuários");
            Console.WriteLine("-------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Usuários");
            Console.WriteLine("2 - Cadastrar Usuário");
            Console.WriteLine("3 - Atualizar Usuário");
            Console.WriteLine("4 - Excluir Usuário");
            Console.WriteLine("5 - Vincular Usuário a uma Role");
            Console.WriteLine("6 - Exibir Usuários com Roles");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    ListUserView.Load();
                    break;
                case 2:
                    CreateUserView.Load();
                    break;
                case 3:
                    UpdateUserView.Load();
                    break;
                case 4:
                    DeleteUserView.Load();
                    break;
                case 5:
                    AddRoleToUserView.Load();
                    break;
                case 6:
                    ListUserWithRolesView.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
