

using GitLearn.Data;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;

namespace GitLearn.Services.Service
{
    public class GitFileService : BaseService<GitFile>, IGitFileService
    {
        public GitFileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
