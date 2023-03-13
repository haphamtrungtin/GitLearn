using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitSimulator.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Team> TeamRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
