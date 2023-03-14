using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repositories.Repository;
using GitLearn.DAL.Repository;
using GitLearn.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace GitSimulator.DAL.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GitContext _context;
        private bool _disposed;
        private IDbContextTransaction _transaction;
        public ITeamRepository teamRepository;
        public IOrganizationRepository orgRepository;
        public ITeamMemberRepository teamMemberRepository;
        public IUserRepository userRepository;
        public IInviteRequestRepository inviteRequestRepository;

        public IInviteRequestRepository InviteRequestRepository
        {
            get
            {
                inviteRequestRepository ??= new InviteRequestRepository(_context);
                return inviteRequestRepository;
            }
        }

        public ITeamRepository TeamRepository
        {
            get
            {
                teamRepository ??= new TeamRepository(_context);
                return teamRepository;
            }
        }
        
        public IOrganizationRepository OrgRepository
        {
            get
            {
                orgRepository ??= new OrganizationRepository(_context);
                return orgRepository;
            }
        }
       
        public IUserRepository UserRepository
        {
            get
            {
                userRepository ??= new UserRepository(_context);
                return userRepository;
            }
        }

        public ITeamMemberRepository TeamMemberRepository
        {
            get
            {
                teamMemberRepository ??= new TeamMemberRepository(_context);
                return teamMemberRepository;
            }
        }
        public UnitOfWork(GitContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();
            _disposed = true;
        }
    }
}
