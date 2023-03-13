using GitLearn.Data;

namespace GitSimulator.DAL.Repository.InviteRequestRepository
{
    public class InviteRequestRepository : GenericRepository<InviteRequest>, IInviteRequestRepository
    {
        public InviteRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
