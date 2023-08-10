using baltaDataAcess.Model;
using baltaDataAcess.Repositories;
using baltaDataAcess.Services;
using Dapper;
using System.Data.SqlClient;


namespace baltaDataAcess
{
    class Dapper
    {
        static void Main()
        {
            DotNetEnv.Env.TraversePath().Load();
            string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
            using (var connection = new SqlConnection(connectionString))
            {
                CategoriesService categoriesService = new(connection);
                CareerItemService careerItemService = new(connection);
                CourseService courseService = new(connection);
                CareerService careerService = new(connection);
                foreach(var cat in categoriesService.Get() ){
                    System.Console.WriteLine($"Nome Categoria -> {cat.Title}");
                }
                //ListCategories(connection);
                //ListCategory(connection, "amazon-aws");
                //OneToOne(connection);
                //OneToMany(connection);
                //QueryMultiple(connection);
                //SelectIn(connection);
                // Like(connection, "api");


            }
        }



        // static void OneToOne(SqlConnection connection)
        // {
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
        // static void OneToMany(SqlConnection connection)
        // {
        //     var sql = @"SELECT [Career].Id,
        //                 [Career].[Title],
        //                 [CareerItem].[CareerId],
        //                 [CareerItem].[Title] From [Career]
        //                 Inner join
        //                 [CareerItem] ON [careerItem].[CareerId] = [Career].[Id]
        //                 Order By
        //                 [Career].[Title]
        //                     ";
        //     var careers = new List<Career>();
        //     var items = connection.Query<Career, CareerItem, Career>(sql, (career, item) =>
        //     {
        //         var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
        //         if (car == null)
        //         {
        //             car = career;
        //             car.CareerItems.Add(item);
        //             careers.Add(car);
        //         }
        //         else
        //             car.CareerItems.Add(item);
        //         return career;
        //     }, splitOn: "CareerId");
        //     foreach (var career in careers)
        //     {
        //         Console.WriteLine($" ID Da Carreira - {career.Id} Titulo da Carreira- {career.Title}");
        //         foreach (var item in career.CareerItems)
        //         {
        //             Console.WriteLine($" - {item.Title}");
        //         }
        //     }
        // }
        // // Many to many
        // static void QueryMultiple(SqlConnection connection)
        // {
        //     var query = @"SELECT * from [Category]; SELECT * FROM [Course]";
        //     using (var multi = connection.QueryMultiple(query))
        //     {
        //         var categories = multi.Read<Category>();
        //         var courses = multi.Read<Course>();

        //         foreach (var item in categories)
        //         {
        //             Console.WriteLine(item.Title);
        //         }
        //         foreach (var item in courses)
        //         {
        //             Console.WriteLine(item.Title);
        //         }
        //     }
        // }

        // static void SelectIn(SqlConnection connection)
        // {
        //     var query = @"select * from career where [Id] in @Id";

        //     var items = connection.Query<Career>(query, new
        //     {
        //         Id = new[] { "01AE8A85-B4E8-4194-A0F1-1C6190AF54CB", "E6730D1C-6870-4DF3-AE68-438624E04C72" }
        //     });

        //     foreach (var item in items)
        //     {
        //         Console.WriteLine(item.Title);
        //     }
        // }


        // static void Transactions(SqlConnection connection, Category category)
        // {
        //     var insertSql = @"Insert into [category] values (
        //                         @Id,
        //                         @Title,
        //                         @Url,
        //                         @Summary,
        //                         @Order,
        //                         @Description,
        //                         @Featured)";
        //     using (var transaction = connection.BeginTransaction())
        //     {
        //         var rows = connection.Execute(insertSql, category, transaction);
        //         transaction.Commit();
        //         transaction.Rollback();
        //         Console.WriteLine($"linhas inseridas - ${rows}");
        //     }
        // }
    }
}
