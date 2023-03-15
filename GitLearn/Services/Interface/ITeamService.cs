
using GitLearn.Data;
using GitLearn.Service;

namespace GitLearn.Services.Interface
{
    public interface ITeamService : IBaseService<Team>
    {
        Team CreateTeam(int orgId, int creatorId, string name);
        Team CreateSubTeam(int parentTeamId, string subTeamName);
        Team CreateTeamWithMembers(int orgId, int creatorId, string teamName, params int[] memberIds);
        Team InviteMemberInsideOrganization(int teamId, params int[] memberId);
        Team InviteMemberOutsideOrganization(int teamId, int requestId);
        Team RemoveMembers(int teamId, params int[] memberId);
        List<TeamMember> ViewMembers(int teamId);
        List<Team> ViewSubTeams(int teamId);
    }
}
