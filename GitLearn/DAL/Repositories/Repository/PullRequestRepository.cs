using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class PullRequestRepository : GenericRepository<PullRequest>, IPullRequestRepository
    {
        public PullRequestRepository(GitContext context) : base(context)
        {
        }
    }
}
