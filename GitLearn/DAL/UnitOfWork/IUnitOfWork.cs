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
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IDbContextTransaction CreateTransaction();
        void Commit();
        void Rollback(string rollbackVersion);
        void SaveChange();
    }
}
