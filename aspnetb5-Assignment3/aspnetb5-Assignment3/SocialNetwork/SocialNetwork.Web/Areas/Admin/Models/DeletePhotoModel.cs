using Autofac;
using SocialNetwork.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class DeletePhotoModel
    {
        private readonly IPhotoService _photoService;
        public DeletePhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public DeletePhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        internal void Delete(int id)
        {
            _photoService.Delete(id);
        }
    }
}
