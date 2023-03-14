using GitLearn.Data;

using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Service.RepoService
{
    public class RepoService : BaseService<Repo>, IRepoService
    {

        public RepoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
