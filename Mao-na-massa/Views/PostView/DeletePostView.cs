using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.PostView
{
    internal class DeletePostView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de Post");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite o id do Post:");
            var id = int.Parse(Console.ReadLine()!);
            Delete(id);

        }

        private static void Delete(int id)
        {
            PostRepository postRepository = new PostRepository();
            postRepository.Delete(id);
            Console.WriteLine("Post excluído com sucesso!");
            Console.ReadLine();
            MenuPostView.Load();

        }
    }
}