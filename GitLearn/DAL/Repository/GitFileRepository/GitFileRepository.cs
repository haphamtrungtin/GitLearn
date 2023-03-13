using GitLearn.Data;

namespace GitSimulator.DAL.Repository.GitFileRepository
{
    internal class GitFileRepository : GenericRepository<GitFile>, IGitFileRepository
    {
        public GitFileRepository(GitContext context) : base(context)
        {
        }
    }
}
