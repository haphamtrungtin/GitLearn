using GitLearn.DAL.UnitOfWork;
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

        internal OrgUser InviteMemberOrganization(int orgId, int memberId)
        {
            var org = _unitOfWork.Repository<Organization>().GetById(orgId);
            bool isExist = org.OrgUsers.Any(ou => ou.UserId.Equals(memberId));
            if (!isExist)
            {
                var orgUser = new OrgUser()
                {
                   Organization=org,
                   OrganizationId=orgId,
                   UserId=memberId,
                   Status = "INVITED"
                };
                _unitOfWork.Repository<OrgUser>().Create(orgUser);
                _unitOfWork.Save();
                return orgUser;
            }
            throw new Exception("User already exists in organization");
        }
        internal InviteRequest InviteMemberRepository(int repoId, int memberId)
        {
            throw new Exception();
        }
    }
}
