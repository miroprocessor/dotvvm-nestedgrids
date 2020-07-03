using System;
using System.Collections.Generic;

namespace GridViews.Web.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Grad> Grads { get; set; }
    }
}