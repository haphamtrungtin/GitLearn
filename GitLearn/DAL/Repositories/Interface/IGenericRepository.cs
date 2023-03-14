using GitLearn.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GitLearn.DAL.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetByCondition(Func<TEntity, bool> predicate);

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete();
        void DeleteById(int id);
    }
}
