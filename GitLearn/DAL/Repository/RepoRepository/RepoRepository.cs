using GitLearn.Data;

namespace GitLearn.DAL.Repository.RepoRepository
{
    public class RepoRepository : GenericRepository<Repo>, IRepoRepository
    {
        public RepoRepository(GitContext context) : base(context)
        {
        }
    }
}
