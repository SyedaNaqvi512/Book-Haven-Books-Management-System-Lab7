
using BMS_CRUD_with_Razor_Pages_ASP_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BMS_CRUD_with_Razor_Pages_ASP_Core.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Book Book { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            string connectionString =
                _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "DefaultConnection was not found in appsettings.json.");

            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "SELECT * FROM dbo.books WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                return NotFound();
            }

            Book = new Book
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                title = reader["title"] as string,
                author = reader["author"] as string,
                description = reader["description"] as string,
                publisher = reader["publisher"] as string,
                status = reader["status"] as string,
                category = reader["category"] as string
            };

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            string connectionString =
                _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "DefaultConnection was not found in appsettings.json.");

            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "DELETE FROM dbo.books WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}
