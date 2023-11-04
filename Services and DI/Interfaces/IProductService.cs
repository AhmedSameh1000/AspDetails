namespace Interfaces
{
    public interface IProductService
    {
        Guid Id { get; }

        public int Id_ins { get; set; }

        List<string> GetProducts();
    }
}