using GitLearn.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSimulator.DAL.Repository.BranchRepository
{
    internal class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(GitContext context) : base(context)
        {
        }
    }
}
