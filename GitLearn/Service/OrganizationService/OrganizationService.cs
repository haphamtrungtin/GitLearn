using GitLearn.Data;
using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator.Service.OrganizationService
{
    public class OrganizationService : BaseService<Organization>, IOrganizationService
    {
        public OrganizationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
