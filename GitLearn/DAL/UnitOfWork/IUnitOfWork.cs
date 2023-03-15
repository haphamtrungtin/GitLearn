using GitLearn.Data;
using GitLearn.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GitLearn.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Team> TeamRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IDbContextTransaction CreateTransaction();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Commit();
        void Rollback(string rollbackVersion);
        void SaveChange();
    }
}
