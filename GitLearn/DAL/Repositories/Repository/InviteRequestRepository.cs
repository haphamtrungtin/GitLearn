using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitLearn.DAL.Repositories.Repository
{
    public class InviteRequestRepository : GenericRepository<InviteRequest>, IInviteRequestRepository
    {
        public InviteRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
