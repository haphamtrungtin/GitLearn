using GitLearn.Data;

namespace GitLearn.DAL.Repository.InviteRequestRepository
{
    public class InviteRequestRepository : GenericRepository<InviteRequest>, IInviteRequestRepository
    {
        public InviteRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
