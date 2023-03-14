using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(GitContext context) : base(context)
        {
        }
    }
}
