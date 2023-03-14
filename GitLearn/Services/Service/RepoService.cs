using GitLearn.Data;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;


namespace GitLearn.Services.Service
{
    public class RepoService : BaseService<Repo>, IRepoService
    {

        public RepoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
