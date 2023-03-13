using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;

namespace GitSimulator.Service.BranchService
{
    public class BranchService : BaseService<Branch>, IBranchService
    {
        public BranchService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}