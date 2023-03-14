using GitLearn.Data;

namespace GitLearn.DAL.Repository.OrganizationRepository
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(GitContext context) : base(context)
        {

        }
    }
}
