



using GitLearn.Data;
using GitLearn.Service.UserService;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;

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