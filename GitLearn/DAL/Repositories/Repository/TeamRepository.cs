using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(GitContext context) : base(context)
        {
        }
    }
}
