using GitLearn.DAL.UnitOfWork;
using GitLearn.Data;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLearn.Services.Service
{
    public class CommitService : BaseService<Commit>, ICommitService
    {
        public CommitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
