using GitSimulator.DAL.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitSimulator.Service.UserService;
using GitLearn.Data;

namespace GitSimulator.Service.TeamService
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Team CreateTeam(int creatorId, string name)
        {
            //var userService = new UserServices(_unitOfWork);
            //User creator = userService.GetUser(creatorId);

            Team newTeam = new()
            {
                Name = name,
                IsParentTeam = true,
            };

            _unitOfWork.TeamRepository.Create(newTeam);
            _unitOfWork.Save();
            return newTeam;
        }
    }
}
