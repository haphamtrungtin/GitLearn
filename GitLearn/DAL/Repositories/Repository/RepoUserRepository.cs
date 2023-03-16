using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class RepoUserRepository : GenericRepository<RepoUser>, IRepoUserRepository
    {
        private readonly GitContext _context;
        public RepoUserRepository(GitContext context) : base(context)
        {
            _context = context;
        }
    }
}