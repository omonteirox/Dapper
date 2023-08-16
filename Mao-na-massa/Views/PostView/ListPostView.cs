using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.PostView
{
    internal class ListPostView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Posts");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadLine();
            MenuPostView.Load();

        }

        private static void List()
        {
            PostRepository repository = new PostRepository();
            var posts = repository.Get();
            foreach (var item in posts)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}