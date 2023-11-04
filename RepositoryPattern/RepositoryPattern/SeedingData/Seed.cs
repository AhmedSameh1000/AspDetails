using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.SeedingData
{
    public class Seed
    {
        private readonly AppDbContext _dbContext;

        public Seed(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedCategoriesAndProducts()
        {
            if (!_dbContext.Categories.Any())
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();
                if (!_dbContext.Categories.Any())
                {
                    _dbContext.Categories.AddRange(LoadCategories());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Products.Any())
                {
                    _dbContext.Products.AddRange(LoadProducts());
                    _dbContext.SaveChanges();
                }
            }
        }

        public IEnumerable<Category> LoadCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Clothing" },
                new Category { Name = "Home & Garden" },
                new Category { Name = "Sports & Outdoors" },
                new Category { Name = "Automotive" },
                new Category { Name = "Books & Literature" },
                new Category { Name = "Health & Wellness" },
                new Category { Name = "Food & Beverages" },
                new Category { Name = "Travel & Leisure" },
                new Category { Name = "Toys & Games" }
            };
        }

        public IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new Product { Name = "Smartphone", CategoryId = 1 },
                new Product { Name = "Laptop", CategoryId = 1 },
                new Product { Name = "T-shirt", CategoryId = 2 },
                new Product { Name = "Sofa", CategoryId = 3 },
                new Product { Name = "Running Shoes", CategoryId = 4 },
                new Product { Name = "Car Battery", CategoryId = 5 },
                new Product { Name = "Novel", CategoryId = 6 },
                new Product { Name = "Vitamins", CategoryId = 7 },
                new Product { Name = "Chocolate", CategoryId = 8 },
                new Product { Name = "Beach Vacation Package", CategoryId = 9 }
            };
        }
    }
}