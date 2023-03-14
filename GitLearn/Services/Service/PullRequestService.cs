using GitLearn.Data;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;


namespace GitLearn.Services.Service
{
    public class PullRequestService : BaseService<PullRequest>, IPullRequestService
    {
        public PullRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}