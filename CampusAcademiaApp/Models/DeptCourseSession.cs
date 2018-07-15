using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CampusAcademiaApp
{
    public class DeptCourseSession
    {
        public virtual int SessionId { get; set; }
        public virtual string SessionStart { get; set; }
        public virtual string SessionEnd { get; set; }
        [Display(Name = "Has Section")]
        public virtual string SessionSections { get; set; }
        public virtual string CourseName { get; set; }
        public virtual string DepartmentName { get; set; }
        [Display(Name = "Created Date")]
        public virtual DateTime? SessionCreateddate { get; set; }
    }
}