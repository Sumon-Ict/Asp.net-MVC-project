using SocialNetwork.Admin.BusinessObject;
using SocialNetwork.Admin.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IAdminUnitOfWork _adminUnitOfWork;
        public PhotoService(IAdminUnitOfWork adminUnitOfWork)
        {
            _adminUnitOfWork = adminUnitOfWork;
        }
        public void Add(Photo photo)
        {
            if (photo == null)
                throw new InvalidOperationException("photo not provided");
            else
            {
                try
                {
                    _adminUnitOfWork.Photos.Add(new Entities.Photo
                    {
                        MemberId = photo.MemberId,
                        PhotoFileNam = photo.PhotoFileNam
                    });
                    _adminUnitOfWork.Save();
                }
                catch
                {
                    throw new Exception("photo not added to db");
                }
            }
        }

        public void Delete(int id)
        {
            try
            {
                _adminUnitOfWork.Photos.Remove(id);
                _adminUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Photo not removed");
            }
        }

        public void Edit(Photo photo)
        {
            if (photo == null)
                throw new InvalidOperationException("photo not provided");
            else
            {
                var photoEntity = _adminUnitOfWork.Photos.GetById(photo.Id);
                if (photoEntity != null)
                {
                    try
                    {
                        photoEntity.MemberId = photo.MemberId;
                        photoEntity.PhotoFileNam = photo.PhotoFileNam;
                        _adminUnitOfWork.Save();
                    }
                    catch
                    {
                        throw new Exception("Not changed photo");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Couldn't find photo");
                }
            }
        }

        public Photo GetPhotoById(int id)
        {
            var photoEntity = _adminUnitOfWork.Photos.GetById(id);
            return new Photo
            {
                Id = photoEntity.Id,
                MemberId = photoEntity.MemberId,
                PhotoFileNam= photoEntity.PhotoFileNam
            };
        }

        public (IList<Photo> records, int total, int totalDisplay) GetPhotos(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var photoData = _adminUnitOfWork.Photos.GetDynamic(
                null, null,
                "", pageIndex, pageSize);
            var resultData = (from photo in photoData.data
                              select new Photo
                              {
                                  Id = photo.Id,
                                  PhotoFileNam = photo.PhotoFileNam,
                                  MemberId = photo.MemberId,
                                  MemberName = photo.Member.Name
                              }).ToList();
            return (resultData, photoData.total, photoData.totalDisplay);
        }
    }
}
