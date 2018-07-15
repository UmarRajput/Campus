using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblNews {
        public virtual int NewsId { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual string NewsDescription { get; set; }
        public virtual DateTime? PostedDate { get; set; }
        public virtual int? PostedBy { get; set; }
    }
}
