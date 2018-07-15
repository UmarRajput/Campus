using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblEveningtime {
        public virtual int EveningtimeId { get; set; }
        [Display(Name = "First Day")]
        [Required(ErrorMessage = "Required")]
        public virtual string EveningtimeDay1 { get; set; }
        [Display(Name = "Start Time ")]
        [Required(ErrorMessage = "Required")]
        public virtual string EveningtimeDay1startlec { get; set; }
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string EveningtimeDay1endlec { get; set; }
        [Display(Name = "Second Day")]
        [Required(ErrorMessage = "Required")]
        public virtual string EveningtimeDay2 { get; set; }
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string EveningtimeDay2startlec { get; set; }
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string EveningtimeDay2endlec { get; set; }
        public virtual int? TimetableId { get; set; }
        public virtual int? TeacherId { get; set; }
        public virtual int? SubjectId { get; set; }
    }
}
