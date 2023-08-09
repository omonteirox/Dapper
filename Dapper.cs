using baltaDataAcess.Model;
using Dapper;
using System.Data.SqlClient;


namespace baltaDataAcess
{
    class Dapper
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();
            string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
            using (var connection = new SqlConnection(connectionString))
            {
                //CreateCategory(connection, new Category
                //{
                //    Id = Guid.NewGuid(),
                //    Title = "Amazon AWS",
                //    Url = "amazon-aws",
                //    Summary = "Amazon AWS",
                //    Order = 1,
                //    Description = "Amazon AWS",
                //    Featured = false
                //});
                // UpdateCategory(connection, new Category
                //{
                //    Id = Guid.Parse("b2c0b4a0-0b7a-4b1e-9f1a-2b7b6b9c9b1a"),
                //    Title = "Amazon AWS",
                //    Url = "amazon-aws",
                //    Summary = "Amazon AWS",
                //    Order = 1,
                //    Description = "Amazon AWS",
                //    Featured = false
                //});
                //ListCategories(connection);
                //ListCategory(connection, "amazon-aws");
                //OneToOne(connection);
                //OneToMany(connection);
                //QueryMultiple(connection);



            }
        }
        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT * FROM CATEGORY");
            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id} - {cat.Title}");
            }
        }
        static void ListCategory(SqlConnection connection, string urlCLient)
        {
            var url = urlCLient.Normalize().ToLower();
            var listQuery = "SELECT * FROM CATEGORY WHERE [Url] = @Url";
            var category = connection.QueryFirst<Category>(listQuery, new { Url = url });
            Console.WriteLine($"{category.Id} - {category.Title}");
        }
        static void CreateCategory(SqlConnection connection, Category category)
        {
            var insertSql = @"Insert into [category] values (
                                @Id,
                                @Title,
                                @Url,
                                @Summary,
                                @Order,
                                @Description,
                                @Featured)";
            var rows = connection.Execute(insertSql, category);
            Console.WriteLine($"linhas inseridas - ${rows}");
        }
        static void UpdateCategory(SqlConnection connection, Category category)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";
            var rows = connection.Execute(updateQuery, category);
            Console.WriteLine($"linhas atualizadas - ${rows}");
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";
            var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
            {
                careerItem.Course = course;
                return careerItem;
            }, splitOn: "Id");
            foreach (var item in items)
            {
                Console.WriteLine($" ID Da Carreira - {item.Id} Titulo da Carreira- {item.Title}  Id do Curso- {item.Course.Id}");
            }
        }
        static void OneToMany(SqlConnection connection)
        {
            var sql = @"SELECT [Career].Id,
                        [Career].[Title],
                        [CareerItem].[CareerId],
                        [CareerItem].[Title] From [Career]
                        Inner join
                        [CareerItem] ON [careerItem].[CareerId] = [Career].[Id]
                        Order By
                        [Career].[Title]
                            ";
            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(sql, (career, item) =>
            {
                var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                if (car == null)
                {
                    car = career;
                    car.CareerItems.Add(item);
                    careers.Add(car);
                }
                else
                    car.CareerItems.Add(item);
                return career;
            }, splitOn: "CareerId");
            foreach (var career in careers)
            {
                Console.WriteLine($" ID Da Carreira - {career.Id} Titulo da Carreira- {career.Title}");
                foreach (var item in career.CareerItems)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }
        // Many to many
        static void QueryMultiple(SqlConnection connection)
        {
            var query = @"SELECT * from [Category]; SELECT * FROM [Course]";
            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach(var item in categories)
                {
                    Console.WriteLine(item.Title);
                }
                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }
    
    }
}
