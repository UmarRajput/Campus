using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblCourse {
        public virtual int CourseId { get; set; }
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets Allowed")]
        public virtual string CourseName { get; set; }
        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z.]+$", ErrorMessage = "No. and Space are not Allowed!")]
        [MinLength(2, ErrorMessage = "Min. length should be 2 character")]
        public virtual string CourseCode { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Required")]
        public virtual int? DepartmentId { get; set; }
    }
}
