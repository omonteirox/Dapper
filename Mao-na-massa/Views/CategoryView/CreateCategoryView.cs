using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.CategoryView
{
    internal class CreateCategoryView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Categorias");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite o nome da categoria:");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o slug da categoria:");
            var slug = Console.ReadLine();
            var category = new Category();
            category.Name = name;
            category.Slug = slug;
            Save(category);

        }

        private static void Save(Category category)
        {
            Repository<Category> categoryRepository = new Repository<Category>();
            categoryRepository.Create(category);
            Console.WriteLine("Categoria cadastrada com sucesso!");
            Console.ReadLine();
            MenuCategoryView.Load();

        }
    }
}