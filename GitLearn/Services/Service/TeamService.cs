using GitSimulator.DAL.UnitOfWork;
using GitLearn.Data;
using GitSimulator.Service;
using GitLearn.Services.Interface;

namespace GitLearn.Services.Service
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Team CreateTeam(int orgId, int creatorId, string name)
        {
            var org = _unitOfWork.OrgRepository.GetById(orgId);
            var user = _unitOfWork.UserRepository.GetById(creatorId);

            Team newTeam = new()
            {
                Name = name,
                IsParentTeam = true,
                IsPublic = true,
                Organization = org,
                OrganizationId = orgId,
            };

            CreateTeamMember(newTeam, user);

            _unitOfWork.TeamRepository.Create(newTeam);
            _unitOfWork.Save();
            return newTeam;
        }

        internal Team CreateTeamWithMember(int orgId, int creatorId, string teamName, params int[] memberIds)
        {
            var org = _unitOfWork.OrgRepository.GetById(orgId);
            var user = _unitOfWork.UserRepository.GetById(creatorId);
            var members = _unitOfWork.UserRepository.GetUserList(memberIds);

            Team newTeam = new()
            {
                Name = teamName,
                IsParentTeam = true,
                IsPublic = true,
                OrganizationId = orgId,
                Organization = org
            };

            CreateTeamMember(newTeam, user);

            foreach (var m in members)
            {
                CreateTeamMember(newTeam, m);
            }

            _unitOfWork.TeamRepository.Create(newTeam);
            _unitOfWork.Save();
            return newTeam;
        }

        internal Team InviteMemberInsideOrganization(int teamId, params int[] memberId)
        {
            var team = _unitOfWork.TeamRepository.GetById(teamId);
            var members = _unitOfWork.UserRepository.GetUserList(memberId).ToList();

            foreach (var m in members)
            {
                if (!CheckIsMemberExistInTeam(team, m))
                {
                    CreateTeamMember(team, m);
                }
            }

            _unitOfWork.Save();
            return team;
        }
        internal Team InviteMemberOutsideOrganization(int teamId, int requestId)
        {
            var team = _unitOfWork.TeamRepository.GetById(teamId);
            var request = _unitOfWork.InviteRequestRepository.GetById(requestId);
            var user = _unitOfWork.UserRepository.GetById(request.ReceiverId);
            if (request.Status.Equals("ACCEPTED"))
            {
                CreateTeamMember(team, user);
                return team;
            }
            throw new Exception("Request is not accepted");
        }

        private static bool CheckIsMemberExistInTeam(Team team, User member)
        {
            return team.TeamMembers.Any(t => t.UserId.Equals(member.Id));
        }

        private void CreateTeamMember(Team newTeam, User user)
        {
            var teamMember = new TeamMember() { Team = newTeam, User = user };
            _unitOfWork.TeamMemberRepository.Create(teamMember);
            
        }

        internal Team RemoveMember(int teamId, params int[] memberId)
        {
            var team = _unitOfWork.TeamRepository.GetById(teamId);

            foreach(var m in memberId)
            {
                var teamMember = team.TeamMembers.FirstOrDefault(tm => tm.UserId.Equals(m));
                team.TeamMembers.Remove(teamMember);
            }

            _unitOfWork.Save();
            return team;   
        }

        internal List<TeamMember> ViewMembers(int teamId)
        {

            throw new NotImplementedException();
        }
    }
}
