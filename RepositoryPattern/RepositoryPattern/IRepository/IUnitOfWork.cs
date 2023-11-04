namespace RepositoryPattern.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();

        void SaveChanges();
    }
}