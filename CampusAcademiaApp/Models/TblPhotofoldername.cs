using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblPhotofoldername {
        public virtual int PhotofoldernameId { get; set; }
        [Display(Name = "Folder Name")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special character are not Allowed")]
        [MaxLength(20, ErrorMessage = "Max. Length should be 20 Character")]
        [MinLength(3, ErrorMessage = "Min. Length should be 3 Character")]
        public virtual string FolderName { get; set; }
    }
}
