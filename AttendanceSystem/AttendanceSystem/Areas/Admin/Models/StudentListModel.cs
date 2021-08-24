using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using AttendanceSystem.Training.BusinessObjects;
using AttendanceSystem.Training.Services;
using Autofac;
using AutoMapper;


namespace AttendanceSystem.Areas.Admin.Models
{
    public class StudentListModel
    {
        private readonly IStudentService _studentService;

        private readonly IMapper _mapper;

        public StudentListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public StudentListModel(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;

        }

        internal object getStudents(DataTablesAjaxRequestModel tableModel)
        {

            var data = _studentService.GetStudents(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "StudentRollNumber"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.StudentRollNumber.ToString(),                              
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
      public void deleteStudent(int id)
        {
            _studentService.DeleteStudent(id);

        }

    }
}
