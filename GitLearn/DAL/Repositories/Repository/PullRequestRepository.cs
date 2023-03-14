using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class PullRequestRepository : GenericRepository<PullRequest>, IPullRequestRepository
    {
        public PullRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
