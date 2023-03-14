using GitLearn.DAL.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLearn.Service.UserService;
using GitLearn.Data;

namespace GitLearn.Service.TeamService
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
            var result = new Team();
            return result;
        }
    }
}
