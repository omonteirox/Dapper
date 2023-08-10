using System.Data.SqlClient;
using baltaDataAcess.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace baltaDataAcess.Utils
{
    public class ToWordDocument
    {
        readonly CategoriesService categoriesService;
        readonly CareerItemService careerItemService;
        readonly CourseService courseService;
        readonly CareerService careerService;
        readonly string filePath = "C:/Users/gmonteirox/Desktop/Consultas.docx";
        public ToWordDocument(SqlConnection connection)
        {
            categoriesService = new(connection);
            careerItemService = new(connection);
            courseService = new(connection);
            careerService = new(connection);
        }
        public void CreateDocument()
        {
            Formatting formatador = new()
            {
                Bold = true
            };
            using var document = DocX.Create(filePath, DocumentTypes.Document);
            document.InsertParagraph("Consulta de nome de  Cursos", false, formatador);
            foreach (var item in courseService.Get())
            {
                document.InsertParagraph(item.Title);
            }
            document.InsertParagraph("Consulta de nome de  Carreiras", false, formatador);
            foreach (var item in careerService.Get())
            {
                document.InsertParagraph(item.Title);
            }
            document.InsertParagraph("Consulta de nome de  Carreiras Itens", false, formatador);
            foreach (var item in careerItemService.Get())
            {
                document.InsertParagraph(item.Title);
            }
            document.InsertParagraph("Consulta de nome de  Categorias", false, formatador);
            foreach (var item in categoriesService.Get())
            {
                document.InsertParagraph(item.Title);
            }
            document.Save();
            System.Console.WriteLine($"Documento Criado no caminho {filePath}");

        }
    }
}