using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator.Service.InviteRequestService
{
    public class InviteRequestService : BaseService<InviteRequest>, IInviteService
    {
        public InviteRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
