using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblLecturetime {
        public virtual int LecturetimeId { get; set; }
        [Display(Name = "Time")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9: ]+$", ErrorMessage = "Special Character are not Allowed")]
        [MaxLength(8, ErrorMessage = "Max. Length should be 8")]
        [MinLength(8, ErrorMessage = "Min. Length should be 8")]
        public virtual string LecturetimeTime { get; set; }
    }
}
