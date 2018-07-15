using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblSession {
        public virtual int SessionId { get; set; }
        [Display(Name = "Session Start")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Year are Allowed")]
        [MinLength(4, ErrorMessage = "Enter Full Year")]
        public virtual string SessionStart { get; set; }
        [Display(Name = "Session End")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Year are Allowed")]
        [MinLength(4, ErrorMessage = "Enter Full Year")]
        public virtual string SessionEnd { get; set; }
        [Display(Name = "Session Has Sections A and B")]
        public virtual string SessionSections { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int DepartmentId { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Required")]
        public virtual int CourseId { get; set; }
        public virtual DateTime? SessionCreateddate { get; set; }
    }
}
