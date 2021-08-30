using Autofac;
using SocialNetwork.Admin.BusinessObject;
using SocialNetwork.Admin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class EditPhotoModel
    {
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string PhotoFileName { get; set; }
        private readonly IPhotoService _photoService;
        public EditPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public EditPhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        internal void LoadModelData(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            Id = photo.Id;
            MemberId = photo.MemberId;
            PhotoFileName = photo.PhotoFileNam;
        }

        internal void Edit()
        {
            _photoService.Edit(new Photo
            {
                Id = Id,
                PhotoFileNam = PhotoFileName,
                MemberId = MemberId
            });
        }
    }
}
