using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblNotes {
        public virtual int NotesId { get; set; }
        [Display(Name = "Topic Name")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual string NotesTopicname { get; set; }
        [Display(Name = "File")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual string NotesFile { get; set; }
        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Field can't be empty")]
        public virtual int? SubjectId { get; set; }
        public virtual int? CourseId { get; set; }
        public virtual int? SessionId { get; set; }
        public virtual int? DepartmentId { get; set; }
        public virtual int? UserId { get; set; }
        public virtual string UserType { get; set; }
        public virtual string UpdatedNotes { get; set; }
        public virtual DateTime? NotesPosteddate { get; set; }
        public virtual int? NotesDownloads { get; set; }
    }
}
