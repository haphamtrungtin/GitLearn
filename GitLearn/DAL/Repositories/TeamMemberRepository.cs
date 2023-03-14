using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitLearn.DAL.Repository
{
    internal class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        private GitContext context;

        public TeamMemberRepository(GitContext context) : base(context)
        {
        }
    }
}