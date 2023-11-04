namespace MVCApplication.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Languge? Language { get; set; }
        public List<string>? Hobbies { get; set; }
    }

    public enum Languge
    {
        English,
        Frensh,
        Arabic
    }
}