using SocialNetwork.Admin.Repositories;
using SocialNetwork.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.UnitOfWorks
{
    public interface IAdminUnitOfWork : IUnitOfWork
    {
        IMemberRepository Members { get; }
        IPhotoRepository Photos { get; }
    }
}
