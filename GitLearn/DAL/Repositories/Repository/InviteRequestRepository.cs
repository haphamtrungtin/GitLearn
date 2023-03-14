using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    public class InviteRequestRepository : GenericRepository<InviteRequest>, IInviteRequestRepository
    {
        public InviteRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
