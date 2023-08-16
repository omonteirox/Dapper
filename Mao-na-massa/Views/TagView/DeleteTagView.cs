using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.TagView
{
    internal class DeleteTagView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Tag");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o Id da Tag");
            var id = int.Parse(Console.ReadLine()!);
            Delete(id);

        }

        private static void Delete(int id)
        {
            Repository<Tag> tagRepository = new Repository<Tag>();
            tagRepository.Delete(id);
            Console.WriteLine("Tag excluída com sucesso!");
            Console.ReadLine();
            MenuTagView.Load();

        }
    }
}