using MaoNaMassa.Models;
using MaoNaMassa.Repositories;
using MaoNaMassa.Views.CategoryView;

namespace MaoNaMassa.Views.PostView
{
    internal class CreatePostView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Post");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite o título do Post:");
            var title = Console.ReadLine();
            Console.WriteLine("Digite o resumo do Post:");
            var summary = Console.ReadLine();
            Console.WriteLine("Digite o Slug do Post:");
            var slug = Console.ReadLine();
            Console.WriteLine("Insira o corpo do Post");
            var body = Console.ReadLine();
            Console.WriteLine("Digite o Id do Autor do Post:");
            var authorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id da Categoria do Post:");
            var categoryId = int.Parse(Console.ReadLine());

            
            var createDate = DateTime.Now;
            var lastUpdateDate = DateTime.Now;

            var post = new Post();
            post.Title = title;
            post.Summary = summary;
            post.Slug = slug;
            post.Body = body;
            post.CreateDate = createDate;
            post.LastUpdateDate = lastUpdateDate;
            post.CategoryId = categoryId;
            post.AuthorId = authorId;

            Save(post);

        }

        private static void Save(Post Post)
        {
            PostRepository postRepository = new PostRepository();
            postRepository.Create(Post);
            Console.WriteLine("Post cadastrado com sucesso!");
            Console.ReadLine();
            MenuCategoryView.Load();

        }
    }
}