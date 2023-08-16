using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaoNaMassa.Models
{
    [Table("Post")]
    public class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public int CategoryId{ get; set; }
        public int AuthorId { get; set; }

        public string Summary { get; set; }
        public string  Slug { get; set; }
        
        [Write(false)]
        public Category Category{ get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        [Write(false)]
        public List<Tag> Tags { get; set; }
        public string Body { get; set; }

        public override string? ToString()
        {
            return $"{Id}, {Title}, {CategoryId}, {AuthorId}, {Summary}, {Slug}, {CreateDate}, {LastUpdateDate}, {Body}";
        }
    }
}

