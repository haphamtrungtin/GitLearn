using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSimulator.Service.CommitService
{
    public class CommitService : BaseService<Commit>, ICommitService
    {
        public CommitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
