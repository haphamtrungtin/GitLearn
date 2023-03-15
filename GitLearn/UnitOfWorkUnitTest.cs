using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using GitLearn.Service.TeamService;
using GitLearn.Service.UserService;
using Microsoft.EntityFrameworkCore;
using System;

namespace GitLearn
{
    [TestClass]
    public class UnitOfWorkUnitTest
    {
        GitContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new GitContext();
            _context.Users.AddRange(new List<User>
            {
                new User { UserName = "Tuan" },
                new User { UserName = "Tin" },
                new User { UserName = "Tien" },
                new User { UserName = "Tung" },
                new User { UserName = "Viet" },
            });
        }

        [TestCleanup]
        public void Clean()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void GetRepositoryTest()
        {
            var uow = new UnitOfWork(_context);
            var result = uow.Repository<User>();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CommitTransactionTest()
        {
            var uow = new UnitOfWork(_context);
            uow.CreateTransaction();
            uow.Commit();
            var result = uow.UserRepository.GetAll().Count();

            Assert.AreEqual(29, result);
        }

        [TestMethod]
        public void CreateTransactionTest() 
        {
            var uow = new UnitOfWork(_context);
            var result = uow.CreateTransaction();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RollbackTransactionTest() 
        {
            var uow = new UnitOfWork( _context);
            uow.CreateTransaction();
            try
            {
                uow.UserRepository.Create(new User() { UserName = "Hoang" });
                var version = "more users";
                uow.SaveChange();
                uow.CreateSavePointTransaction(version);

                uow.UserRepository.DeleteById(150);
                uow.SaveChange();
                uow.Commit();
            }
            catch(Exception)
            {
                uow.Rollback("more users");
            }

            var result = uow.UserRepository.GetAll().Count();
            Assert.AreEqual(59, result);
        }

        [TestMethod]
        public void UsingService_With_UOW_Test()
        {
            var uow = new UnitOfWork(_context);
            var userService = new UserServices(uow);
            var result = userService.GetById(100);

            Assert.IsNotNull(result);
        }
    }
}