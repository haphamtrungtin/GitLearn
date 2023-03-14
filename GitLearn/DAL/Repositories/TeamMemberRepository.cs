using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
    

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