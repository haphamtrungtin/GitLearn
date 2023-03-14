using GitLearn.Data;
using GitLearn.Services.Interface;
using GitSimulator.DAL.UnitOfWork;
using GitSimulator.Service;


namespace GitLearn.Services.Service
{
    public class OrganizationService : BaseService<Organization>, IOrganizationService
    {
        public OrganizationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
