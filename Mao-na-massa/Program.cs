using MaoNaMassa;
using MaoNaMassa.Views;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=gadmin22@;Trusted_Connection=False; TrustServerCertificate=True;";
    public static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        Database.Connection.Open();
        MenuView.Load();
        Database.Connection.Close();
    }
    
}