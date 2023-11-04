using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService, IDisposable
    {
        private Guid _Id;
        private List<string> _Products;
        public Guid Id => _Id;

        public int Id_ins { get; set; }

        public ProductService()
        {
            _Id = Guid.NewGuid();
            _Products = new List<string>()
             {
              "Mobile","Laptop","Printer","TV"
             };
        }

        public List<string> GetProducts()
        {
            return _Products;
        }

        public void Dispose()
        {
        }
    }
}