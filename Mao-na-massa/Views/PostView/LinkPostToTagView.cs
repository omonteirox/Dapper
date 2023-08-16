using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.PostView
{
    internal class LinkPostToTagView
    {
        internal static void Load()
        {
            Console.WriteLine("Vincular Post em uma tag");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o id do post");
            var postId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o id da tag");
            var tagId = int.Parse(Console.ReadLine()!);
            Link(postId, tagId);
            

        }

        private static void Link(int postId, int tagId)
        {
            PostRepository postRepository = new PostRepository();
            postRepository.AddTag(postId, tagId);
            Console.WriteLine("Post vinculado com sucesso!");
            Console.ReadLine();
            MenuPostView.Load();
        }
    }
}