using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;

namespace GitLearn.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        //ITeamRepository TeamRepository { get; }
        //IOrganizationRepository OrgRepository { get; }
        //IUserRepository UserRepository { get; }
        //ITeamMemberRepository TeamMemberRepository { get; }
        //IInviteRequestRepository InviteRequestRepository { get; }
        //IRepoUserRepository RepoUserRepository { get; }
        //IOrgUserRepository OrgUserRepository { get; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
