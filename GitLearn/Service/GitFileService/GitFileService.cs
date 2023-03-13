

using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;

namespace GitSimulator.Service.GitFileService
{
    public class GitFileService : BaseService<GitFile>, IGitFileService
    {
        public GitFileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
