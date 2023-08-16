using MaoNaMassa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaoNaMassa.Views.PostView
{
    internal class ListPostWithCategoryView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Posts com Categoria");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadLine();
            MenuPostView.Load();

        }
        public static void List()
        {
            PostRepository repository = new PostRepository();
            var posts = repository.GetWithCategory();
            foreach (var item in posts)
            {
                Console.WriteLine($"{item.ToString()} \n Categoria: {item.Category.ToString()}");             
            }

        }
    }
}
