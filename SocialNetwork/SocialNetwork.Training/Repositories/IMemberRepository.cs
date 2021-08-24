using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Data;
using SocialNetwork.Training.Entities;

namespace SocialNetwork.Training.Repositories
{
  public  interface IMemberRepository : IRepository<Member,int>
    {
    }

}
