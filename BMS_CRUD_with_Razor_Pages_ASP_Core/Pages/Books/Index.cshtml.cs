using BMS_CRUD_with_Razor_Pages_ASP_Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BMS_CRUD_with_Razor_Pages_ASP_Core.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Book> Books { get; set; } = new();

        public void OnGet()
        {
            string connectionString =
                _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "The DefaultConnection connection string was not found in appsettings.json.");

            using SqlConnection connection =
                new SqlConnection(connectionString);

            connection.Open();

            const string query =
                @"SELECT Id, title, author, description, publisher, status, category
                  FROM dbo.books
                  ORDER BY Id DESC";

            using SqlCommand command =
                new SqlCommand(query, connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Books.Add(new Book
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),

                    title = reader["title"] as string,

                    author = reader["author"] as string,

                    description = reader["description"] as string,

                    publisher = reader["publisher"] as string,

                    status = reader["status"] as string,

                    category = reader["category"] as string
                });
            }
        }
    }
}
