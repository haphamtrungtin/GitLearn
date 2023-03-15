using GitLearn.Data;
using GitLearn.DAL.Repository;
using GitLearn.DAL.Repository.TeamRepository;
using GitLearn.DAL.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GitLearn.DAL.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GitContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _transaction;

        private Dictionary<(Type type, string name), object> _repositories;

        public IGenericRepository<Team> teamRepository;
        public IGenericRepository<User> userRepository;

        public IGenericRepository<Team> TeamRepository
        {
            get
            {
                if (teamRepository is null)
                {
                    teamRepository = new GenericRepository<Team>(_context);
                }
                return teamRepository;
            }
        }
        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (userRepository is null)
                {
                    userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
        }

        public UnitOfWork(GitContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return (IGenericRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new GenericRepository<TEntity>(_context));
        }

        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public IDbContextTransaction CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback(string rollbackVersion)
        {
            _transaction.RollbackToSavepoint(rollbackVersion);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void CreateSavePointTransaction(string savepointVersion)
        {
            _transaction.CreateSavepoint(savepointVersion);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();
            _disposed = true;
        }

        internal object GetOrAddRepository(Type type, object repo)
        {
            _repositories ??= new Dictionary<(Type type, string Name), object>();

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) return repository;
            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }

    }
}
