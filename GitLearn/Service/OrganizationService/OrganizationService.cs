using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitLearn.Service.OrganizationService
{
    public class OrganizationService : BaseService<Organization>, IOrganizationService
    {
        public OrganizationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
