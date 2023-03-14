using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Service.InviteRequestService
{
    public class InviteRequestService : BaseService<InviteRequest>, IInviteService
    {
        public InviteRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
