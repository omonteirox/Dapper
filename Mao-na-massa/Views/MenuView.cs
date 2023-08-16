using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaoNaMassa.Views
{
    public class MenuView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Sistema de Gerenciamento");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1 - Gerenciamento de Categorias");
            Console.WriteLine("2 - Gerenciamento de Posts");
            Console.WriteLine("3 - Gerenciamento de Roles");
            Console.WriteLine("4 - Gerenciamento de Tags");
            Console.WriteLine("5 - Gerenciamento de Usuários");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    CategoryView.MenuCategoryView.Load();
                    break;
                case 2:
                    PostView.MenuPostView.Load();
                    break;
                case 3:
                    RoleView.MenuRoleView.Load();
                    break;
                case 4:
                    TagView.MenuTagView.Load();
                    break;
                case 5:
                    UserView.MenuUserView.Load();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Load();
                    break;
            }

        }
    }
}
