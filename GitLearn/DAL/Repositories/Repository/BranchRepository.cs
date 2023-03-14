using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(GitContext context) : base(context)
        {
        }
    }
}
