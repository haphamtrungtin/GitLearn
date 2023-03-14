using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class CommitRepository : GenericRepository<Commit>, ICommitRepository
    {
        public CommitRepository(GitContext context) : base(context)
        {
        }
    }
}
