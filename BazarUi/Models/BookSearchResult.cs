namespace BazarUi.Models
{
    public class BookSearchResult
    {
        public string Title { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public int CopiesInStock { get; set; }
        public int Price { get; set; }

    }
}