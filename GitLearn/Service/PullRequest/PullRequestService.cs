using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator.Service.PullRequestService
{
    public class PullRequestService : BaseService<PullRequest>, IPullRequestService
    {
        public PullRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}