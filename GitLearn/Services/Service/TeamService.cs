using GitSimulator.DAL.UnitOfWork;
using GitLearn.Data;
using GitSimulator.Service;
using GitLearn.Services.Interface;
using GitLearn.DAL.UnitOfWork;
using AutoMapper;
using GitLearn.DAL.Repositories.Interface;

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
            var org = _unitOfWork.Repository<Organization>().GetById(orgId);
            var user = _unitOfWork.Repository<User>().GetById(creatorId);

            Team newTeam = new()
            {
                Name = name,
                IsParentTeam = true,
                IsPublic = true,
                Organization = org,
                OrganizationId = orgId,
            };

            CreateTeamMember(newTeam, user);

            _unitOfWork.Repository<Team>().Create(newTeam);
            _unitOfWork.Save();
            return newTeam;
        }
        public Team CreateSubTeam(int parentTeamId, string subTeamName)
        {
            var team = _unitOfWork.Repository<Team>().GetById(parentTeamId);

            Team newTeam = new()
            {
                IsParentTeam = false,
                IsPublic = true,
                Name = subTeamName,
                Organization = team.Organization,
                OrganizationId = team.OrganizationId,
                ParentTeam = team,
                ParentTeamId = parentTeamId,
            };

            _unitOfWork.Repository<Team>().Create(newTeam);
            _unitOfWork.Save();
            return newTeam;
        }
        public Team CreateTeamWithMembers(int orgId, int creatorId, string teamName, params int[] memberIds)
        {
            var userService = new UserServices(_unitOfWork);
            var org = _unitOfWork.Repository<Organization>().GetById(orgId);
            var user = _unitOfWork.Repository<User>().GetById(creatorId);
            var members = userService.GetUserList(memberIds);

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

            _unitOfWork.Repository<Team>().Create(newTeam);
            _unitOfWork.Save();
            return newTeam;
        }
        public Team InviteMemberInsideOrganization(int teamId, params int[] memberId)
        {
            var userService = new UserServices(_unitOfWork);
            var team = _unitOfWork.Repository<Team>().GetById(teamId);
            var members = userService.GetUserList(memberId).ToList();

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
        public Team InviteMemberOutsideOrganization(int teamId, int requestId)
        {
            var team = _unitOfWork.Repository<Team>().GetById(teamId);
            var request = _unitOfWork.Repository<OrgUser>().GetById(requestId);
            var user = _unitOfWork.Repository<User>().GetById(request.UserId);

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
            _unitOfWork.Repository<TeamMember>().Create(teamMember);

        }
        public Team RemoveMembers(int teamId, params int[] memberId)
        {
            var team = _unitOfWork.Repository<Team>().GetById(teamId);

            foreach (var m in memberId)
            {
                var teamMember = team.TeamMembers.FirstOrDefault(tm => tm.UserId.Equals(m));
                team.TeamMembers.Remove(teamMember);
            }

            _unitOfWork.Save();
            return team;
        }

        public List<TeamMember> ViewMembers(int teamId)
        {
            var teamMember = _unitOfWork.Repository<TeamMember>().GetByCondition(tm => tm.TeamId.Equals(teamId)).ToList();
            return teamMember;
        }
        public List<Team> ViewSubTeams(int teamId)
        {
            var subTeam = _unitOfWork.Repository<Team>().GetByCondition(t => t.ParentTeamId.Equals(teamId)).ToList();
            return subTeam;
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            var team = await _unitOfWork.Repository<Team>().GetByIdAsync(id);
            return team;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            var teams = await _unitOfWork.Repository<Team>().GetAllAsync();
            return teams;
        }
        public void Delete(Team team)
        {
            _unitOfWork.Repository<Team>().Delete(team);
        }

        
    }
}
