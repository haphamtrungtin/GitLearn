﻿using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;
    

namespace GitLearn.DAL.Repositories.Repository
{
    internal class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(GitContext context) : base(context)
        {
        }
    }
}
