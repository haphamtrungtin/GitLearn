using GitLearn.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSimulator.DAL.Repository.CommitRepository
{
    internal class CommitRepository : GenericRepository<Commit>, ICommitRepository
    {
        public CommitRepository(GitContext context) : base(context)
        {
        }
    }
}
