

namespace MaoNaMassa.Views.PostView
{
    internal class MenuPostView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Posts");
            Console.WriteLine("-------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Posts");
            Console.WriteLine("2 - Cadastrar Post");
            Console.WriteLine("3 - Atualizar Post");
            Console.WriteLine("4 - Excluir Post");
            Console.WriteLine("5 - Vincular post em uma Categoria");
            Console.WriteLine("6 - Listar Todos os posts com suas categorias");
            Console.WriteLine("7 - Listar todos os posts com suas Tags");
            Console.WriteLine("8 - Vincular post em uma Tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    ListPostView.Load();
                    break;
                case 2:
                    CreatePostView.Load();
                    break;
                case 3:
                    UpdatePostView.Load();
                    break;
                case 4:
                    DeletePostView.Load();
                    break;
                case 5:
                    LinkPostToCategoryView.Load();
                    break;
                case 6:
                    ListPostWithCategoryView.Load();
                    break;
                case 7:
                    ListPostWithTagsView.Load();
                    break;
                case 8:
                    LinkPostToTagView.Load();
                    break;
                default:
                    Load();
                    break;
            }


        }
    }
}

