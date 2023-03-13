using GitLearn.Data;

using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator.Service.RepoService
{
    public class RepoService : BaseService<Repo>, IRepoService
    {

        public RepoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
