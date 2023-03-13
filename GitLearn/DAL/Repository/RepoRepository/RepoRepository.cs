using GitLearn.Data;

namespace GitSimulator.DAL.Repository.RepoRepository
{
    public class RepoRepository : GenericRepository<Repo>, IRepoRepository
    {
        public RepoRepository(GitContext context) : base(context)
        {
        }
    }
}
