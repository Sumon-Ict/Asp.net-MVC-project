using SocialNetwork.Admin.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.Services
{
    public interface IPhotoService
    {
        (IList<Photo> records, int total, int totalDisplay) GetPhotos(
            int pageIndex, int pageSize, string searchText, string sortText);
        void Add(Photo photo);
        void Delete(int id);
        Photo GetPhotoById(int id);
        void Edit(Photo photo);
    }
}
