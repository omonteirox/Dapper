using MaoNaMassa.Models;
using MaoNaMassa.Repositories;
using MaoNaMassa.Views.TagView;

namespace MaoNaMassa.Views.TagView
{
    internal class CreateTagView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o nome da Tag");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o Slug da Tag");
            var slug = Console.ReadLine();

            var tag = new Tag();
            tag.Name = name;
            tag.Slug = slug;

            Save(tag);
        }
        internal static void Save(Tag tag)
        {
            Repository<Tag> tagRepository = new Repository<Tag>();
            tagRepository.Create(tag);
            Console.WriteLine("Tag cadastrado com sucesso!");
            Console.ReadLine();
            MenuTagView.Load();
        }
    }
}