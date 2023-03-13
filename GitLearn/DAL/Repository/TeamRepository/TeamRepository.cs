using GitLearn.Data;

namespace GitSimulator.DAL.Repository.TeamRepository
{
    internal class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(GitContext context) : base(context)
        {
        }
    }
}
