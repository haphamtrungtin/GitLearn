using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{

    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(GitContext context) : base(context)
        {

        }
    }
}
