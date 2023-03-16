using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.DAL.UnitOfWork;
using GitLearn.Service;
using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public void Create(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Create(entity);
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Delete(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Repository<TEntity>().GetAll();
        }


        public TEntity GetById(int id)
        {
            return _unitOfWork.Repository<TEntity>().GetById(id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _unitOfWork.Repository<TEntity>().GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
          return await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);
        }
    }
}
