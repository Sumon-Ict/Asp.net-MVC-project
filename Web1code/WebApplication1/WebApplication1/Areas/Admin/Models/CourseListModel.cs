using FirstDemo.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FirstDemo.Training.BusinessObjects;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Areas.Admin.Models
{
    public class CourseListModel
    {
        private ICourseService _courseService;

        private IHttpContextAccessor _httpContextAccessor;

      

        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public CourseListModel(ICourseService courseService,IHttpContextAccessor httpContextAccessor)
        {
            _courseService = courseService;
            _httpContextAccessor = httpContextAccessor;
        }
       

        internal object GetCourses(DataTablesAjaxRequestModel tableModel)
        {
     

            var data = _courseService.GetCourses(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Title", "Fees", "StartDate" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Title,
                                record.Fees.ToString(),
                                record.StartDate.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _courseService.DeleteCourse(id);

        }
    }
}
