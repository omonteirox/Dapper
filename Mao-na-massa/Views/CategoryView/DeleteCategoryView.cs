using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.CategoryView
{
    internal class DeleteCategoryView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de Categorias");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite o Id da categorida:");
            var id = int.Parse(Console.ReadLine()!);
            Delete(id);


        }

        private static void Delete(int id)
        {
            Repository<Category> categoryRepository = new Repository<Category>();
            categoryRepository.Delete(id);
            Console.WriteLine("Categoria excluída com sucesso!");
            Console.ReadLine();
            MenuCategoryView.Load();
        }
    }
}