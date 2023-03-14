using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Service;
using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_repository = _unitOfWork.GetRepository<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
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
    }
}
