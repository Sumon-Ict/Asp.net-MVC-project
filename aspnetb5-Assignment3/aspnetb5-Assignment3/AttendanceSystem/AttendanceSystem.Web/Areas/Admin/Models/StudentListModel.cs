using AttendanceSystem.TNA.Services;
using AttendanceSystem.Web.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class StudentListModel
    {
        private readonly IStudentService _studentService;
        public StudentListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        internal object GetStudents(DataTablesAjaxRequestModel dataTablesAjaxRequestModel)
        {
            var data = _studentService.GetStudents(
                    dataTablesAjaxRequestModel.PageIndex,
                    dataTablesAjaxRequestModel.PageSize,
                    dataTablesAjaxRequestModel.SearchText,
                    dataTablesAjaxRequestModel.GetSortText(new string[] { "Name", "StudentRollNumber" })
                );
            return new {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.StudentRollNumber.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
