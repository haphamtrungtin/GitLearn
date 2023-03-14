using GitLearn.Data;

namespace GitLearn.DAL.Repository.TeamRepository
{
    internal class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(GitContext context) : base(context)
        {
        }
    }
}
