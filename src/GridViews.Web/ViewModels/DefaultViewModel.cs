using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using GridViews.Web.DAL.Entities;
using GridViews.Web.Models;
using GridViews.Web.Services;

namespace GridViews.Web.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly StudentService _studentService;

        public DefaultViewModel(StudentService studentService)
        {
            _studentService = studentService;
        }

        //[Bind(Direction.ServerToClient)]
        public GridViewDataSet<StudentListModel> Students { get; set; } = new GridViewDataSet<StudentListModel>()
        {
            RowEditOptions = { PrimaryKeyPropertyName = "Id" }
        };

        public override async Task PreRender()
        {
            if (Students.IsRefreshRequired)
            {
                var queryable = await _studentService.GetAllStudentsAsync();
                queryable.ForEach(x =>
                {
                    x.Grades = new GridViewDataSet<GradeModel>()
                    {
                        RowEditOptions = { PrimaryKeyPropertyName = "GradeId" }
                    };
                    x.Grades.LoadFromQueryable(x.StudentGrades.AsQueryable());
                });
                Students.LoadFromQueryable(queryable.AsQueryable());
            }
            await base.PreRender();
        }

        public void EditGrade(StudentListModel student, GradeModel grade)
        {
            //var student = Students.Items.Where(x => x.Grades.Items.Any(y => y.GradeId == grade.GradeId)).First();
            student.Grades.RowEditOptions.EditRowId = grade.GradeId;
        }

        public void UpdateGrade(GradeModel model)
        { }

        public void UpdateStudent(StudentListModel model)
        { }

        public void EditStudent(StudentListModel student)
        {
            Students.RowEditOptions.EditRowId = student.Id;
        }

        public void CancelEditGrade()
        {
        }

        public void CancelEditStudent()
        {
            Students.RowEditOptions.EditRowId = null;
            Students.RequestRefresh();
        }
    }
}