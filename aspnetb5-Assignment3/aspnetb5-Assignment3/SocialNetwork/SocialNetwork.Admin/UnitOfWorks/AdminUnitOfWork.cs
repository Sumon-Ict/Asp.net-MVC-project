using Microsoft.EntityFrameworkCore;
using SocialNetwork.Admin.Contexts;
using SocialNetwork.Admin.Repositories;
using SocialNetwork.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.UnitOfWorks
{
    class AdminUnitOfWork : UnitOfWork, IAdminUnitOfWork
    {
        public AdminUnitOfWork(IAdminDbContext adminDbContext ,IMemberRepository members, IPhotoRepository photos)
            : base((DbContext)adminDbContext)
        {
            Members = members;
            Photos = photos;
        }

        public IMemberRepository Members { get; }
        public IPhotoRepository Photos { get; }
    }
}
