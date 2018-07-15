using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblBooks {
        public virtual int BookId { get; set; }
        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "Required")]
        [MinLength(2, ErrorMessage = "Min. length should be 2 character")]
        public virtual string BookTitle { get; set; }
        [Display(Name = "Book Author")]
        [MinLength(3, ErrorMessage = "Min. length should be 2 character")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets Allowed")]
        public virtual string BookAuthor { get; set; }
        [Display(Name = "Book File")]
       // [Required(ErrorMessage = "Required")]
        [DataType(DataType.Upload),Required(ErrorMessage="Required File")]
    //FileExtensions(ErrorMessage = "Please specify a valid .xml file", Extensions = ".xml")]
        public virtual string File { get; set; }
        public virtual int? BookDownloads { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int? DepartmentId { get; set; }
    }
}
