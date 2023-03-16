using GitLearn.DAL.UnitOfWork;
using GitLearn.Data;
using GitLearn.Service.BranchService;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;

namespace GitLearn.Services.Service
{
    public class BranchService : BaseService<Branch>, IBranchService
    {
        public BranchService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}