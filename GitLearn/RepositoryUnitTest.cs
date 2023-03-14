using GitLearn.Data;
using GitLearn.DAL.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GitLearn
{
    [TestClass]
    public class RepositoryUnitTest
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
            _context.SaveChanges();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void DeleteById_Existing_User_Test()
        {
            var userId = 81;
            var userRepository = new UserRepository(_context);
            userRepository.DeleteById(userId);
            var result = userRepository.GetAll().Count();

            Assert.AreEqual(14, result);
        }

        [TestMethod]
        public void Delete_All_Existing_Test()
        {
            var userRepository = new UserRepository(_context);
            userRepository.Delete();

            var result = userRepository.GetAll().Count();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Update_Exisit_User_Test()
        {
            var userRepository = new UserRepository(_context);
            var newUserName = "Duong";
            var userId = 51;
            var user = userRepository.GetById(userId);
            user.UserName = newUserName;
            
            userRepository.Update(user);

            _context.SaveChanges();

            Assert.AreEqual(newUserName, user.UserName);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var userRepository = new UserRepository(_context);
            var result = userRepository.GetAll();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_Should_Return_The_User_Test()
        {
            var userRepository = new UserRepository(_context);
            var userId = 51;

            var result = userRepository.GetById(userId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByCondition_Should_Return_Specific_User_Test()
        {
            var userRepository = new UserRepository(_context);
            var userName = "Tien";
            Expression<Func<User, bool>> predicate = x => x.UserName.Equals(userName);

            var result = userRepository.Find(predicate);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_But_Id_Does_Not_Exist_Test()
        {

        }

        [TestMethod]
        public void Update_But_Record_Does_Not_Exist_Test()
        {

        }

        [TestMethod]
        public void DeleteById_But_Id_Does_Not_Exists_Test()
        {

        }

        [TestMethod]
        public void Delete_But_Entity_Does_Not_Containt_Data_Test()
        {

        }
    }
}
