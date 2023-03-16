using System.Linq.Expressions;

namespace GitLearn.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity GetById(int? id);
        Task<TEntity> GetByIdAsync(int? id);
        IEnumerable<TEntity> GetByCondition(Func<TEntity, bool> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
    }
}

