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
    public class AddPhotoModel
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string PhotoFileName { get; set; }
        private readonly IPhotoService _photoService;
        public AddPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public AddPhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        internal void AddPhoto()
        {
            _photoService.Add(new Photo 
            {
                MemberId = MemberId,
                PhotoFileNam = PhotoFileName
            });
        }
    }
}
