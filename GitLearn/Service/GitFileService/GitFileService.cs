

using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Service.GitFileService
{
    public class GitFileService : BaseService<GitFile>, IGitFileService
    {
        public GitFileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
