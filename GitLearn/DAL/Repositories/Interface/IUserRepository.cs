using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUserList(int[] ids);
    }
}
