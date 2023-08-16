using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.TagView
{
    internal class ListTagView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Tags");
            Console.WriteLine("-------------------------");
            List();

        }

        private static void List()
        {
            Repository<Tag> tagRepository = new Repository<Tag>();
            var tags = tagRepository.Get();
            foreach (var item in tags)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}