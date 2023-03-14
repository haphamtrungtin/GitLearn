using GitLearn.Data;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;


namespace GitLearn.Services.Service
{
    public class InviteRequestService : BaseService<InviteRequest>, IInviteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InviteRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        internal InviteRequest InviteMemberOrganization(int orgId, int memberId)
        {
            var org = _unitOfWork.OrgRepository.GetById(orgId);
            bool isExist = org.OrgUsers.Any(ou => ou.UserId.Equals(memberId));
            if (!isExist)
            {
                var inviteRequest = new InviteRequest()
                {
                    Organization = org,
                    OrganizationId = orgId,
                    ReceiverId = memberId,
                    Status = "SENT"
                };
                _unitOfWork.InviteRequestRepository.Create(inviteRequest);
                _unitOfWork.Save();
                return inviteRequest;
            }
            throw new Exception("User already exists in organization");
        }
        internal InviteRequest InviteMemberRepository(int repoId, int memberId)
        {
            throw new Exception();
        }
    }
}
