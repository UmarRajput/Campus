using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblTimetable {
        public virtual int TimetableId { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int? DepartmentId { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Required")]
        public virtual int? CourseId { get; set; }
        [Display(Name = "Session")]
        [Required(ErrorMessage = "Required")]
        public virtual int? SessionId { get; set; }
        [Display(Name = "Choose Section")]
        public virtual string ClassSection { get; set; }
    }
}
