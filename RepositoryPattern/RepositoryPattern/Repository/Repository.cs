using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.IRepository;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RepositoryPattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _DbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _DbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            //_DbSet.Add(entity);
            _dbContext.Set<T>().Add(entity);
        }

        public void Remove(T Entity)
        {
            //_DbSet.Remove(entity);
            _dbContext.Set<T>().Remove(Entity);
        }

        public IEnumerable<T> GetAll(string[] InclueProperties = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>().AsQueryable();
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return Query.ToList();

            //IQueryable<T> Query =  _DbSet.AsQueryable();
            //return Query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string[] InclueProperties = null)
        {
            //IQueryable<T> Query = _DbSet.AsQueryable();

            //Query = Query.Where(filter);

            //return Query.FirstOrDefault();

            IQueryable<T> Query = _dbContext.Set<T>().AsQueryable();
            Query = Query.Where(filter);
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return Query.FirstOrDefault();
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            //_dbContext.RemoveRange(Entities);
            //_DbSet.RemoveRange(Entities);
            _dbContext.Set<T>().RemoveRange(Entities);
        }
    }
}