using GitLearn.DAL.Repositories.Interface;
using GitLearn.Data;
using GitSimulator.DAL.Repository;

namespace GitSimulator.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITeamRepository TeamRepository { get; }
        IOrganizationRepository OrgRepository { get; }
        IUserRepository UserRepository { get; }
        ITeamMemberRepository TeamMemberRepository { get; }
        IInviteRequestRepository InviteRequestRepository { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
