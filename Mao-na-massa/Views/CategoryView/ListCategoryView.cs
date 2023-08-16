using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.CategoryView
{
    internal class ListCategoryView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Categorias");
            Console.WriteLine("-------------------------");
            List();
            Console.ReadKey();
            MenuCategoryView.Load();

        }
        internal static void List()
        {
            Repository<Category> repository = new Repository<Category>();
            var categories = repository.Get();
            foreach (var category in categories)
            {
                Console.WriteLine(category.ToString());
            }

        }
    }
}