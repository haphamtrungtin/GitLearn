using GitLearn.DAL.Repository;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLearn.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<TEntity> _repository;


        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity);
        }

        public void Delete()
        {
            _repository.Delete();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        IQueryable<TEntity> IBaseService<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
