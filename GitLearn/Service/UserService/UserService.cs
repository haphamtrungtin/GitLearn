

using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;

namespace GitSimulator.Service.UserService
{
    public class UserServices : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        internal User GetUser(int creatorId)
        {
            //_unitOfWork.GetRepository<User>();
            return _unitOfWork.UserRepository.GetById(creatorId);
        }
    }
}
