using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblEvents {
        public virtual int EventId { get; set; }
        [Display(Name = "Event Title")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual string EventTitle { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual string EventDescription { get; set; }
        [Display(Name = "Event Date")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual DateTime? EventDate { get; set; }
        [Display(Name = "Event Image")]
        public virtual string EventImage { get; set; }
        public virtual DateTime? PostedDate { get; set; }
        public virtual int? PostedBy { get; set; }
    }
}
