using GitLearn.Data;

namespace GitLearn.Service.UserService
{
    internal interface IUserService : IBaseService<User>
    {
        IEnumerable<User> GetUserList(int[] ids);
    }
}
