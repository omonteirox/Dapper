using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.PostView
{
    internal class LinkPostToCategoryView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Link de Post com Categoria");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite o id do Post:");
            var idPost = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o id da Categoria:");
            var idCategory = int.Parse(Console.ReadLine()!);
            Link(idPost, idCategory);

        }

        private static void Link(int idPost, int idCategory)
        {
            PostRepository postRepository = new PostRepository();
            postRepository.AddCategory(idCategory, idPost);
            Console.WriteLine("Categoria vinculada com sucesso!");
            Console.WriteLine();
            Console.ReadLine();
            MenuPostView.Load();
        }
    }
}