using GitLearn.Data;

namespace GitLearn.DAL.Repository.GitFileRepository
{
    internal class GitFileRepository : GenericRepository<GitFile>, IGitFileRepository
    {
        public GitFileRepository(GitContext context) : base(context)
        {
        }
    }
}
