using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLearn.Data;
using GitLearn.Services.Service;
using GitSimulator.DAL.UnitOfWork;

namespace GitLearn
{
    [TestClass]
    public class TeamServiceTest
    {
        GitContext _context;
        private IUnitOfWork _uow;
        private TeamService _teamService;
        private InviteRequestService _inviteRequestService;
        private UserServices _userService;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new GitContext();
            _context.Users.AddRange(new List<User>
            {
                new User { UserName = "Tuan" },
                new User { UserName = "Tin" },
                new User { UserName = "Tien" },
                new User { UserName = "Tung" },
                new User { UserName = "Viet" },
            });

            _context.Repoes.AddRange(new List<Repo>
            {
                new Repo { Name = "RepoA"},
                new Repo { Name = "RepoB" },
                new Repo { Name = "RepoC" },
                new Repo { Name = "RepoD" },
                new Repo { Name = "RepoE" }
            });

            _context.Branches.AddRange(new List<Branch>
            {
                new Branch { Name = "BrachA" },
                new Branch { Name = "BrachB" },
                new Branch { Name = "BrachC" },
                new Branch { Name = "BrachD" },
                new Branch { Name = "BrachE" },
            });

            _context.Teams.AddRange(new List<Team>()
            {
                new Team {Name="Team1"},
                new Team {Name="Team2"},
            });

            _context.Organizations.AddRange(new List<Organization>()
            {
                new Organization{ OrgName ="Org1", OwnerId=1},
                new Organization{ OrgName ="Org2", OwnerId=1},
            });

            _context.SaveChanges();
            _uow = new UnitOfWork(_context);
            _teamService = new TeamService(_uow);
            _inviteRequestService = new InviteRequestService(_uow);
            _userService = new UserServices(_uow);
        }

        [TestCleanup]
        public void Clean()
        {
            _context.Dispose();
      
        }
        [TestMethod]
        public void CreateTeam_WithCreator_Test()
        {
            var teamName = "New Team";
            var creatorId = 1;
            var orgId = 1;
            var newTeam = _teamService.CreateTeam(orgId, creatorId, teamName);

            Assert.AreEqual(newTeam.Name, teamName);
        }

        [TestMethod]
        public void CreateTeam_SubTeam_Test()
        {
            var teamName = "New Team";
            var creatorId = 1;
            var orgId = 1;
            var newTeam = _teamService.CreateTeam(orgId, creatorId, teamName);

            Assert.AreEqual(newTeam.Name, teamName);

            var subTeamName = "Sub team";
            var subteam = _teamService.CreateSubTeam(newTeam.Id, subTeamName);

            Assert.AreEqual(newTeam, subteam.ParentTeam);
            Assert.AreEqual(subTeamName, subteam.Name);
        }

        [TestMethod]
        public void CreateTeam_WithCreator_OneMember_Test()
        {
            var teamName = "New Team with one member";
            var creatorId = 1;
            var memberId = 2;
            var orgId = 1;
            var newTeam = _teamService.CreateTeamWithMember(orgId, creatorId, teamName, memberId);

            Assert.AreEqual(teamName, newTeam.Name);
            Assert.AreEqual(2, newTeam.TeamMembers.Count);
        }
        [TestMethod]
        public void CreateTeam_WithCreator_MultiMember_Test()
        {
            var teamName = "New Team with multi members";
            var creatorId = 1;
            var orgId = 1;
            int[] memberIds =
            {
                2, 4, 6
            };

            var newTeam = _teamService.CreateTeamWithMember(orgId, creatorId, teamName, memberIds);

            Assert.AreEqual(teamName, newTeam.Name);
            Assert.AreEqual(4, newTeam.TeamMembers.Count);
        }

        [TestMethod]
        public void InviteMember_InsideOrganization_OneMember_Test()
        {
            var teamId = 1;
            var memberId = 2;
            var team = _teamService.InviteMemberInsideOrganization(teamId, memberId);

            Assert.AreEqual(1, team.TeamMembers.Count);
        }

        [TestMethod]
        public void InviteMember_InsideOrganization_MultiMember_Test()
        {
            var teamId = 1;
            int[] memberIds =
            {
                2 , 4, 6,
            };
            var team = _teamService.InviteMemberInsideOrganization(teamId, memberIds);

            Assert.AreEqual(3, team.TeamMembers.Count);
        }

        [TestMethod]
        public void InviteTeam_ExistingMember_Test()
        {
            var teamId = 1;
            int[] memberIds =
            {
                2 , 2, 6, 6, 2, 1
            };
            var team = _teamService.InviteMemberInsideOrganization(teamId, memberIds);

            Assert.AreEqual(3, team.TeamMembers.Count);
        }

        [TestMethod]
        public void InviteMember_OutsideOrganization_Test()
        {
            var teamName = "New Team";
            var creatorId = 1;
            var orgId = 1;
            var memberId = 2;
            var newTeam = _teamService.CreateTeam(orgId, creatorId, teamName);

            Assert.AreEqual(newTeam.Name, teamName);

            var inviteRequest = _inviteRequestService.InviteMemberOrganization(orgId, memberId);
            var acceptedRequest = _userService.AcceptInvitation(inviteRequest.Id);
            var team = _teamService.InviteMemberOutsideOrganization(newTeam.Id, acceptedRequest.Id);

            Assert.AreEqual(2, team.TeamMembers.Count);
        }

      
        [TestMethod]
        public void RemoveMember_OneMember_Test()
        {
            int teamId = 1;
            int memberId = 2;
            int[] memberIds =
            {
                2 , 4, 6,
            };

            _teamService.InviteMemberInsideOrganization(teamId, memberIds);

            var removedTeam = _teamService.RemoveMember(teamId, memberId);

            Assert.AreEqual(2, removedTeam.TeamMembers.Count);
        }

        [TestMethod]
        public void RemoveMember_MultiMember_Test()
        {
            int teamId = 1;
            int[] removeMemberIds =
            {
                2, 4, 6,
            };

            int[] memberIds =
            {
                2 , 4, 6, 8, 10
            };

            _teamService.InviteMemberInsideOrganization(teamId, memberIds);

            var removedTeam = _teamService.RemoveMember(teamId, removeMemberIds);

            Assert.AreEqual(2, removedTeam.TeamMembers.Count);
        }

        [TestMethod]
        public void View_MemberList()
        {
            var teamId = 1;

            var teamMembers = _teamService.ViewMembers(teamId);

            Assert.AreEqual(14, teamMembers.Count);
        }
        [TestMethod]
        public void View_SubTeamList()
        {
            var teamName = "New Team";
            var creatorId = 1;
            var orgId = 1;
            var subTeamName = "Sub team";
            var newTeam = _teamService.CreateTeam(orgId, creatorId, teamName);
            _teamService.CreateSubTeam(newTeam.Id, subTeamName);
            var subTeams = _teamService.ViewSubTeams(newTeam.Id);

            Assert.AreEqual(1, subTeams.Count);
        }

        [TestMethod]
        public void View_MemberById()
        {

        } 
        [TestMethod]
        public void View_MemberByRole()
        {

        }
    }
}
