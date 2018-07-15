using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblPhotogallery {
        public virtual int PhotogalleryId { get; set; }
        [Display(Name = "Select Images")]
        [Required(ErrorMessage = "Required")]
        public virtual string Image { get; set; }
        [Display(Name = "Select Images")]
        public virtual int? PhotofoldernameId { get; set; }
        
    }
}
