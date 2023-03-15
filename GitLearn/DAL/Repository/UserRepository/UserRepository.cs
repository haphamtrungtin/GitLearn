using GitLearn.Data;
using GitLearn.Service.RepoService;
using GitLearn.Service.UserService;

namespace GitLearn.DAL.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GitContext context) : base(context)
        {
        }
    }
}
