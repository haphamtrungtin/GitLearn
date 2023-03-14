using GitLearn.Data;
using GitSimulator.Service;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;

namespace GitLearn.Service.InviteRequestService
{
    public class InviteRequestService : BaseService<InviteRequest>, IInviteService
    {
        public InviteRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
