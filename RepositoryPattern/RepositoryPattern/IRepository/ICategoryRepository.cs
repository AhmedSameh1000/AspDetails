using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

        void SaveChanges();
    }
}