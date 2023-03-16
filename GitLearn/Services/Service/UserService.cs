



using GitLearn.DAL.UnitOfWork;
using GitLearn.Data;
using GitLearn.Service.UserService;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Services.Service
{
    public class UserServices : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        internal OrgUser AcceptInvitation(int requestId)
        {
            var request = _unitOfWork.Repository<OrgUser>().GetById(requestId);
            request.Status = "ACCEPTED";
            return request;
        }

        public IEnumerable<User> GetUserList(int[] ids)
        {
            return _unitOfWork.Repository<User>().GetAll().Where(t => ids.Contains(t.Id));
        }
    }
}