using GitLearn.Data;
using GitSimulator.DAL.Repository;
using GitSimulator.DAL.Repository.TeamRepository;
using GitSimulator.DAL.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSimulator.DAL.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GitContext _context;
        private bool _disposed;
        private Hashtable _repositories;
        private IDbContextTransaction _transaction;
        public IGenericRepository<Team> teamRepository;
        public IGenericRepository<User> userRepository;

        public IGenericRepository<Team> TeamRepository
        {
            get
            {
                if (teamRepository != null)
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
                if (userRepository != null)
                {
                    userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
        }

        public UnitOfWork(GitContext context)
        {
            _context = context;
            _repositories= new Hashtable();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
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
