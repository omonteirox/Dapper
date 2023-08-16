using Dapper.Contrib.Extensions;


namespace MaoNaMassa.Models
{
    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public override string? ToString()
        {
            return $"{Id}, {Name}, {Slug}";
        }
        //public List<Post> Posts { get; set; }


    }
}
