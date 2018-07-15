using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblMorningtime {
        public virtual int MorningtimeId { get; set; }
        [Display(Name = "First Day")]
        [Required(ErrorMessage = "Required")]
        public virtual string MorningtimeDay1 { get; set; }
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string MorningtimeDay1startlec { get; set; }
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string MorningtimeDay1endlec { get; set; }
        [Display(Name = "Second Day")]
        [Required(ErrorMessage = "Required")]
        public virtual string MorningtimeDay2 { get; set; }
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string MorningtimeDay2startlec { get; set; }
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Required")]
        public virtual string MorningtimeDay2endlec { get; set; }
        public virtual int? TimetableId { get; set; }
        [Display(Name = "Teacher")]
        [Required(ErrorMessage = "Required")]
        public virtual int? TeacherId { get; set; }
        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Required")]
        public virtual int? SubjectId { get; set; }
    }
}
