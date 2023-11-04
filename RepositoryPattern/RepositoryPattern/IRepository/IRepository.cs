using System.Linq.Expressions;

namespace RepositoryPattern.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string[] InclueProperties = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string[] InclueProperties = null);

        void Add(T entity);

        void Remove(T Entity);

        void RemoveRange(IEnumerable<T> Entities);
    }
}