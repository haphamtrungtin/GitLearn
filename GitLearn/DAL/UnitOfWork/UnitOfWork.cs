using System.Collections;
using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repositories.Repository;
using GitLearn.DAL.Repository;
using GitLearn.DAL.UnitOfWork;
using GitLearn.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace GitSimulator.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GitContext _context;
        private bool _disposed;
        private IDbContextTransaction _transaction;
        //public ITeamRepository teamRepository;
        //public IOrganizationRepository orgRepository;
        //public ITeamMemberRepository teamMemberRepository;
        //public IUserRepository userRepository;
        //public IInviteRequestRepository inviteRequestRepository;
        //public IRepoUserRepository repoUserRepository;
        //public IOrgUserRepository orgUserRepository;
        private Hashtable _repos;

        //public IInviteRequestRepository InviteRequestRepository
        //{
        //    get
        //    {
        //        inviteRequestRepository ??= new InviteRequestRepository(_context);
        //        return inviteRequestRepository;
        //    }
        //}

        //public ITeamRepository TeamRepository
        //{
        //    get
        //    {
        //        teamRepository ??= new TeamRepository(_context);
        //        return teamRepository;
        //    }
        //}
        
        //public IOrganizationRepository OrgRepository
        //{
        //    get
        //    {
        //        orgRepository ??= new OrganizationRepository(_context);
        //        return orgRepository;
        //    }
        //}
       
        //public IUserRepository UserRepository
        //{
        //    get
        //    {
        //        userRepository ??= new UserRepository(_context);
        //        return userRepository;
        //    }
        //}

        //public ITeamMemberRepository TeamMemberRepository
        //{
        //    get
        //    {
        //        teamMemberRepository ??= new TeamMemberRepository(_context);
        //        return teamMemberRepository;
        //    }
        //}
        //public IRepoUserRepository RepoUserRepository
        //{
        //    get
        //    {
        //        repoUserRepository ??= new RepoUserRepository(_context);
        //        return repoUserRepository;
        //    }
        //}
        //public IOrgUserRepository OrgUserRepository
        //{
        //    get
        //    {
        //        orgUserRepository ??= new OrgUserRepository(_context);
        //        return orgUserRepository;
        //    }
        //}

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
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repos is null)
                _repos = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!_repos.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repos.Add(type, repository);
            }
            return (IGenericRepository<TEntity>)_repos[type];
        }
    }
}
