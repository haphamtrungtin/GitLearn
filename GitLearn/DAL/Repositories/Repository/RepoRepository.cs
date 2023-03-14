using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitLearn.DAL.Repositories.Repository
{
    public class RepoRepository : GenericRepository<Repo>, IRepoRepository
    {
        public RepoRepository(GitContext context) : base(context)
        {
        }
    }
}
