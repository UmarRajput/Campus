using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CampusAcademiaApp {
    
    public class TblSubject {
        public virtual int SubjectId { get; set; }
        [Display(Name = "Subject Title")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets Allowed")]
        public virtual string SubjectTitle { get; set; }
        [Display(Name = "Subject Code")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9-]+$", ErrorMessage = "Write Correct format")]
        [MinLength(2, ErrorMessage = "Min. length should be 2 character")]
        public virtual string SubjectCode { get; set; }
        [Display(Name = "Credit Hour")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Number are Allowed")]
        [Range(1, 6, ErrorMessage = "Only 1 to 6 are Allowed")]
        public virtual int SubjectCredithour { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int DepartmentId { get; set; }
    }
}
