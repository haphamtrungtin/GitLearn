using GitLearn.Data;

namespace GitLearn.DAL.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GitContext context) : base(context)
        {
        }
    }
}
