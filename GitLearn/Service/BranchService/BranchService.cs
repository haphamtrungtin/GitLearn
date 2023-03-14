using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Service.BranchService
{
    public class BranchService : BaseService<Branch>, IBranchService
    {
        public BranchService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}