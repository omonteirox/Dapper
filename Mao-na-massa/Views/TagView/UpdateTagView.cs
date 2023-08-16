using MaoNaMassa.Models;
using MaoNaMassa.Repositories;

namespace MaoNaMassa.Views.TagView
{
    internal class UpdateTagView
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Tag");
            Console.WriteLine("-------------------------");
            Update();
            Console.ReadLine();
            MenuTagView.Load();

        }

        private static void Update()
        {
            Repository<Tag> repository = new Repository<Tag>();
            Console.WriteLine("Digite o Id da Tag que deseja atualizar:");
            var id = Console.ReadLine();
            var tag = repository.GetById(Convert.ToInt32(id));
            if (tag != null)
            {
                Console.WriteLine("Digite o nome da Tag:");
                tag.Name = Console.ReadLine();
                Console.WriteLine("Digite o Slug da Tag:");
                tag.Slug = Console.ReadLine();
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Tag não encontrada!");
            }
            

        }
    }
}