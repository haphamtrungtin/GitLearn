using GitLearn.Data;
using GitLearn.Services.Service;
using GitSimulator.DAL.UnitOfWork;


namespace GitSimulator
{
    [TestClass]
    public class UnitTest1
    {
        GitContext _context;
        private  IUnitOfWork _uow;

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

            _context.Repoes.AddRange(new List<Repo>
            {
                new Repo { Name = "RepoA"},
                new Repo { Name = "RepoB" },
                new Repo { Name = "RepoC" },
                new Repo { Name = "RepoD" },
                new Repo { Name = "RepoE" }
            });

            _context.Branches.AddRange(new List<Branch>
            {
                new Branch { Name = "BrachA" },
                new Branch { Name = "BrachB" },
                new Branch { Name = "BrachC" },
                new Branch { Name = "BrachD" },
                new Branch { Name = "BrachE" },
            });

            _context.Teams.Add(new Team()
            {
                Name="team"
            });
            _context.SaveChanges();
             _uow = new UnitOfWork(_context);
        }

        [TestCleanup]
        public void Clean()
        {
            _context.Dispose();
        }
        /// <summary>
        /// Test case: invite member
        /// </summary>
        [TestMethod]
        public void InviteMemberTest()
        {
            Assert.IsNotNull(_context);
        }

       
        [TestMethod]
        public void RemoveTeamMemberTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void CreateBranchTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void CreateSubBranchTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void GetCodeByBranchTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ClondeCodeTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ViewLastFileTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ViewPullRequestTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ViewPullRequestByIdTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ViewOlderVersionFileTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ViewLatestVersionFileTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void GetNumbersOfVersionFileTest()
        {
            Assert.IsNotNull(_context);
        }

        [TestMethod]
        public void ServiceTest()
        {
            var userService = new UserServices(_uow);

            var result = userService.GetById(1);

            Assert.IsNotNull(result);
        }
    }
}