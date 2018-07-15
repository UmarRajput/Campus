using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CampusAcademiaApp
{
    public class DeptCourseView
    {
        public virtual int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public virtual string CourseName { get; set; }
        [Display(Name = "Course Code")]
        public virtual string CourseCode { get; set; }
      [Display(Name = "Department Name")]
        public virtual string DepartmentName { get; set; }
    }
}