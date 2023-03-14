using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLearn.Service.CommitService
{
    public class CommitService : BaseService<Commit>, ICommitService
    {
        public CommitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
