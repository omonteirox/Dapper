using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.CategoryView
{
    internal class UpdateCategoryView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Categoria");
            Console.WriteLine("-------------------------");
            Update();
            Console.ReadLine();
            MenuCategoryView.Load();

            
        }
        private static void Update()
        {
            Repository<Category> repository = new Repository<Category>();
            Console.WriteLine("Digite o Id da Categoria que deseja atualizar:");
            var id = Console.ReadLine();
            var category = repository.GetById(Convert.ToInt32(id));
            if (category != null)
            {
                Console.WriteLine("Digite o nome da Categoria:");
                category.Name = Console.ReadLine();
                Console.WriteLine("Digite o Slug da Categoria:");
                category.Slug = Console.ReadLine();
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada!");
            }
        }
    }
}