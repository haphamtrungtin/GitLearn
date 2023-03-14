using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class GitFileRepository : GenericRepository<GitFile>, IGitFileRepository
    {
        public GitFileRepository(GitContext context) : base(context)
        {
        }
    }
}
