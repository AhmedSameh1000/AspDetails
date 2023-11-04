namespace FirstApp.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Auther { get; set; }

        public string GetBook()
        {
            return $"Book Object - BookId {Id} , Auther {Auther}";
        }
    }
}
