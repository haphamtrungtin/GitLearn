


using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly GitContext _context;
        public UserRepository(GitContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUserList(int[] ids)
        {
            return _context.Users.Where(t => ids.Contains(t.Id));
        }
    }
}
