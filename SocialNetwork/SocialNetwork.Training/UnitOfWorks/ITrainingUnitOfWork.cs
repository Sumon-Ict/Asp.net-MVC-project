using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Data;
using SocialNetwork.Training.Repositories;

namespace SocialNetwork.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IMemberRepository Members { get;  }
    }
}
