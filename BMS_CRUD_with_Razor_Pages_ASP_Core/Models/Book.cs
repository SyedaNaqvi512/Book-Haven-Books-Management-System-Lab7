
namespace BMS_CRUD_with_Razor_Pages_ASP_Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string? title { get; set; }

        public string? author { get; set; }

        public string? description { get; set; }

        public string? publisher { get; set; }

        public string? status { get; set; }

        public string? category { get; set; }
    }
}
