using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;

namespace GridViews.Web.Models
{
    public class StudentListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<GradeModel> StudentGrades { get; set; }

        [Bind(Direction.ServerToClient)]
        public GridViewDataSet<GradeModel> Grades { get; set; }
    }
}