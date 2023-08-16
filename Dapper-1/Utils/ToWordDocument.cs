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
        
        public ToWordDocument(SqlConnection connection)
        {
            categoriesService = new(connection);
            careerItemService = new(connection);
            courseService = new(connection);
            careerService = new(connection);
        }
        public  void CreateDocument()
        {
         string folderName = $"Pasta do Dia {DateTime.Now.ToString("dd-MM-yyyy")}";
         string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), folderName);
         Directory.CreateDirectory(filePath);
            filePath = Path.Combine(filePath, $"Relatorio do dia {DateTime.Now.ToString("dd-MM-yyyy")}.docx");
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