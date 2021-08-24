using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Training.Contexts;
using SocialNetwork.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Training.UnitOfWorks
{
  public   class TrainingUnitOfWork  : UnitOfWork, ITrainingUnitOfWork
    {
       public  IMemberRepository Members { get; private set; }
        public TrainingUnitOfWork(ITrainingContext context,IMemberRepository members)
            : base((DbContext)context)
        {
            Members = members;
        }
    }
}
