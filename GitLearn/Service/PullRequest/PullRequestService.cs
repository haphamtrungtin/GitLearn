using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Service.PullRequestService
{
    public class PullRequestService : BaseService<PullRequest>, IPullRequestService
    {
        public PullRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}