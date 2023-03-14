using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GitLearn.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly GitContext _context;
        internal DbSet<TEntity> _dbSet;


        public GenericRepository(GitContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetByCondition(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        
    }
}
