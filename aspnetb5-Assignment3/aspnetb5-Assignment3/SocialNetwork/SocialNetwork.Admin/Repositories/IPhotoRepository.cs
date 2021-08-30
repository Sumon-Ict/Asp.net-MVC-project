using SocialNetwork.Admin.Entities;
using SocialNetwork.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.Repositories
{
    public interface IPhotoRepository : IRepository<Photo, int>
    {
    }
}
