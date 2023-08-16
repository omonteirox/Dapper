using MaoNaMassa.Models;
using MaoNaMassa.Repositories;
using MaoNaMassa.Views.PostView;

namespace MaoNaMassa.Views.PostView
{
    internal class UpdatePostView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Post");
            Console.WriteLine("-------------------------");
            Update();
            Console.ReadLine();
            MenuPostView.Load();


        }
        private static void Update()
        {
            PostRepository repository = new PostRepository();
            Console.WriteLine("Digite o Id do Post que deseja atualizar:");
            var id = Console.ReadLine();
            var post = repository.GetById(Convert.ToInt32(id));
            if (post != null)
            {
                Console.WriteLine("Digite o nome do Post:");
                post.Title = Console.ReadLine();
                repository.Update(post);
                Console.WriteLine("Post atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada!");
            }
        }
    }
}