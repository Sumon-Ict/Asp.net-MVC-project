using Autofac;
using SocialNetwork.Admin.Services;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class PhotoListModel
    {
        private readonly IPhotoService _photoService;
        public PhotoListModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public PhotoListModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        internal object GetPhotos(DataTablesAjaxRequestModel dataTablesAjaxRequestModel)
        {
            var data = _photoService.GetPhotos(
                    dataTablesAjaxRequestModel.PageIndex,
                    dataTablesAjaxRequestModel.PageSize,
                    dataTablesAjaxRequestModel.SearchText,
                    dataTablesAjaxRequestModel.GetSortText(new string[] {  })
                );
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.MemberName,
                            record.PhotoFileNam,
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
