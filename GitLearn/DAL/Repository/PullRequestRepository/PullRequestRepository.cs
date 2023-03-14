using GitLearn.Data;

namespace GitLearn.DAL.Repository.PullRequestRepository
{
    internal class PullRequestRepository : GenericRepository<PullRequest>, IPullRequestRepository
    {
        public PullRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
