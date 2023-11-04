namespace MVCApplication.Models
{
    public class PersonProductRapper
    {
        public Person? Person { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}