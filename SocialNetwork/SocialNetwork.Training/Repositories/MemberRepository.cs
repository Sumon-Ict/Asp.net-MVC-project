using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Training.Contexts;
using SocialNetwork.Training.Entities;


namespace SocialNetwork.Training.Repositories
{
  public  class MemberRepository : Repository<Member, int>,  IMemberRepository
    {

        public MemberRepository(ITrainingContext context)
            : base ((DbContext)context)
        {

        }

    }

}
