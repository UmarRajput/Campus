using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CampusAcademiaApp
{
    public class TimeTableSessionView
    {
        public virtual int TimetableId { get; set; }
        [Display(Name = "Department Name")]
        public virtual string DepartmentName { get; set; }
        [Display(Name = "Department Code")]
        public virtual string DepartmentCode { get; set; }
        [Display(Name = "Course Name")]
        public virtual string CourseName { get; set; }
        [Display(Name = "Course Code")]
        public virtual string CourseCode { get; set; }
        [Display(Name = "Session")]
        public virtual string SessionStart { get; set; }
        [Display(Name = "Session End")]
        public virtual string SessionEnd { get; set; }
        [Display(Name = "Class Section")]
        public virtual string ClassSection { get; set; }
    }
}