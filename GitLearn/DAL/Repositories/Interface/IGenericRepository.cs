using System.Linq.Expressions;

namespace GitLearn.DAL.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetByCondition(Func<TEntity, bool> predicate);
    }
    namespace GitLearn.DAL.Repository
    {
        public interface IGenericRepository<TEntity> where TEntity : class
        {
            IQueryable<TEntity> GetAll();
            IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
            TEntity GetById(int id);
            void Create(TEntity entity);
            void Update(TEntity entity);
            void Delete();
            void DeleteById(int id);
        }
    }
}
