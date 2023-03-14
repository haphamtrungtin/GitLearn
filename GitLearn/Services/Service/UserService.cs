

using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;
using GitSimulator.Service.UserService;

namespace GitLearn.Services.Service
{
    public class UserServices : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        internal InviteRequest AcceptInvitation(int requestId)
        {
            var request = _unitOfWork.InviteRequestRepository.GetById(requestId);
            request.Status = "ACCEPTED";
            return request;
        }
    }
}