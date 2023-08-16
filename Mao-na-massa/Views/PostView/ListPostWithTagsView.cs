using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.PostView
{
    internal class ListPostWithTagsView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Posts com Tags");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadLine();
            MenuPostView.Load();

        }
        public static void List()
        {
            PostRepository repository = new PostRepository();
            var posts = repository.GetWithTags();
            foreach (var item in posts)
            {
                
                foreach (var tag in item.Tags)
                {
                    Console.WriteLine($"{item.ToString()} \n Tag: {tag.ToString()}");
                }
            }

        }
    }
}