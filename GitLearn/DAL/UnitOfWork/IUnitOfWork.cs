using GitLearn.Data;
using GitLearn.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Team> TeamRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void CreateTransaction();
        void Commit();
        void Rollback();
        void SaveChange();
    }
}
