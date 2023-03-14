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
    internal class CommitRepository : GenericRepository<Commit>, ICommitRepository
    {
        public CommitRepository(GitContext context) : base(context)
        {
        }
    }
}
