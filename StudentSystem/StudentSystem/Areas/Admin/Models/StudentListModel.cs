using Autofac;
using AutoMapper;
using StudentSystem.Models;
using StudentSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Areas.Admin.Models
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

        public StudentListModel(IStudentService studentService, IMapper mapper)
        {
            _mapper = mapper;
            _studentService = studentService;

        }

        internal Object getStudents(DataTablesAjaxRequestModel tableModel)
        {
            var data = _studentService.GetStudents(
               tableModel.PageIndex,
               tableModel.PageSize,
               tableModel.SearchText,
               tableModel.GetSortText(new string[] { "Name", "Address", "DateOfBirth","Roll","PhoneNumber","CGPA" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Address,
                                record.DateOfBirth.ToString(),
                                record.Roll.ToString(),
                                record.PhoneNumber,
                                record.CGPA.ToString(),
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
