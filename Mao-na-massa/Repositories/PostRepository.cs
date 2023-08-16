using Dapper;
using MaoNaMassa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaoNaMassa.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public void AddCategory(int categoryId, int postId) {
            Repository<Category> categoryRepository = new Repository<Category>();
            var category = categoryRepository.GetById(categoryId);
            var query = @"UPDATE [Post] SET [CategoryId] = @CategoryId WHERE [Id] = @Id";
            Database.Connection.Execute(query, new { CategoryId = category.Id, Id = postId });
        }
        public void AddTag(int postId, int tagId)
        {
            PostRepository postRepository = new PostRepository();
            Repository<Tag> repository = new Repository<Tag>(); 
            var tag = repository.GetById(tagId);
            var post = postRepository.GetById(postId);
            var query = @"INSERT INTO [PostTag] ([PostId], [TagId]) VALUES (@PostId, @TagId)";
            Database.Connection.Execute(query, new { TagId = tag.Id, PostId = post.Id});
        }
        public List<Post> GetWithCategory()
        {
            var query = @"
                        SELECT [Post].*, [Category].*
                        
                        FROM [Post]
                        
                        LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]";
            var posts = new List<Post>();
            var items = Database.Connection.Query<Post, Category, Post>(query, (post, category) =>
            {
                var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                if (pst == null)
                {
                    pst = post;
                    if (category != null)
                    {
                        pst.Category = category;
                    }
                    posts.Add(pst);
                }
                else
                    pst.Category = category;

                return post;
            }, splitOn: "Id");
            return posts;
        }
        public List<Post> GetWithTags()
        {
            var query = @"
                        SELECT [Post].*, [Tag].*
                        
                        FROM [Post]
                        
                        LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                        LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";
            var posts = new List<Post>();
            var items = Database.Connection.Query<Post, Tag, Post>(query, (post, tag) =>
            {
                var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                if (pst == null)
                {
                    pst = post;
                    if (tag != null)
                    {
                        pst.Tags.Add(tag);
                    }
                    posts.Add(pst);
                }
                else
                    pst.Tags.Add(tag);

                return post;
            }, splitOn: "Id");
            return posts;
        }
    }

}

 //     var sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";
//     var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
//     {
//         careerItem.Course = course;
//         return careerItem;
//     }, splitOn: "Id");
//     foreach (var item in items)
//     {
//         Console.WriteLine($" ID Da Carreira - {item.Id} Titulo da Carreira- {item.Title}  Id do Curso- {item.Course.Id}");
//     }
// }