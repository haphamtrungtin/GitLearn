using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repository;
using GitLearn.Data;

namespace GitLearn.DAL.Repositories.Repository
{
    internal class OrgUserRepository : GenericRepository<OrgUser>, IOrgUserRepository
    {
        private readonly GitContext _context;
        public OrgUserRepository(GitContext context) : base(context)
        {
            _context = context;
        }
    }
}
