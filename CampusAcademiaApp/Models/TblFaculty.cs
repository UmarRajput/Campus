using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblFaculty {
        public virtual int FacultyId { get; set; }
        [Display(Name = "Event Title")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual int? DepartmentId { get; set; }
        [Display(Name = "Event Title")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual int? TeacherId { get; set; }
    }
}
