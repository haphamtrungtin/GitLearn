using GitLearn.Data;

namespace GitSimulator.DAL.Repository.PullRequestRepository
{
    internal class PullRequestRepository : GenericRepository<PullRequest>, IPullRequestRepository
    {
        public PullRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
