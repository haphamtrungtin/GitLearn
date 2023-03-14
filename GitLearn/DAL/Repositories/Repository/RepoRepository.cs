using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;
    

namespace GitLearn.DAL.Repositories.Repository
{
    public class RepoRepository : GenericRepository<Repo>, IRepoRepository
    {
        public RepoRepository(GitContext context) : base(context)
        {
        }
    }
}
