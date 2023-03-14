using GitLearn.Data;
using GitLearn.DAL.UnitOfWork;
using GitLearn.Service.TeamService;
using GitLearn.Service.UserService;
using Microsoft.EntityFrameworkCore;

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
        public void GetRepository_Test()
        {
            var uow = new UnitOfWork(_context);
            var result = uow.GetRepository<User>();
            var result1 = uow.GetRepository<User>();

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
            uow.CreateTransaction();

            var result = uow.GetTransaction();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RollbackTransactionTest() 
        {
            var uow = new UnitOfWork( _context);
            uow.CreateTransaction();
            uow.UserRepository.Create(new User() { UserName = "Hoang" });
            uow.Rollback();
            uow.SaveChange();

            var result = uow.UserRepository.GetAll().Count();
            Assert.AreEqual(45, result);
        }

    }
}