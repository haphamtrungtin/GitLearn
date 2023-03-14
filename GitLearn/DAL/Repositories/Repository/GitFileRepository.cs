using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class GitFileRepository : GenericRepository<GitFile>, IGitFileRepository
    {
        public GitFileRepository(GitContext context) : base(context)
        {
        }
    }
}
