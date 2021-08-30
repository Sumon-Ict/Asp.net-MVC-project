using Microsoft.EntityFrameworkCore;
using SocialNetwork.Admin.Contexts;
using SocialNetwork.Admin.Entities;
using SocialNetwork.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.Repositories
{
    public class MemberRepository : Repository<Member, int>, IMemberRepository
    {
        public MemberRepository(IAdminDbContext adminDbContext) :
            base((DbContext)adminDbContext)
        {

        }
    }
}
