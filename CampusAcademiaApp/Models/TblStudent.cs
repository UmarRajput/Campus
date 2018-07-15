using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    public class TblStudent {
        public virtual int StudentId { get; set; }
        [Display(Name = "Roll Number")]
        [Required(ErrorMessage = "Roll Number is Required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only Alphabets Allowed")]
       // [MaxLength(10, ErrorMessage = "Max. length should be 10 character")]
       // [MinLength(2, ErrorMessage = "Min. length should be 2 character")]
        public virtual string StudentRollnumber { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets Allowed")]
        //[MaxLength(10, ErrorMessage = "Max. length should be 10 character")]
        [MinLength(3, ErrorMessage = "Min. length should be 3 character")]
        public virtual string StudentName { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public virtual string StudentGender { get; set; }
         [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "DOB is Required")]
        public virtual DateTime? StudentDob { get; set; }
         [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        public virtual string StudentEmail { get; set; }
         [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile Number is Required")]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = "Only Mobile Number")]
        public virtual string StudentPhonenumber { get; set; }
         [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int? DepartmentId { get; set; }
         [Display(Name = "Course")]
        [Required(ErrorMessage = "Required")]
        public virtual int? CourseId { get; set; }
         [Display(Name = "Session")]
        [Required(ErrorMessage = "Required")]
        public virtual int? SessionId { get; set; }
         [Display(Name = "Your Section")]
        //[Required(ErrorMessage = "Required")]
        public virtual string StudentSection { get; set; }
         [Display(Name = "Class Time")]
       // [Required(ErrorMessage = "Required")]
        public virtual string StudentClasstime { get; set; }
       [Display(Name = "Password")]
        [MaxLength(10, ErrorMessage = "Max. length should be 10")]
        [MinLength(5, ErrorMessage = "Mini. length should be 5")]
        [Required(ErrorMessage = "Password must be required")]
        [DataType(DataType.Password)]
        public virtual string StudentPassword { get; set; }
        [Display(Name = "Profile Image")]
        //[Required(ErrorMessage = "Required")]
        public virtual string StudentImage { get; set; }
        public virtual string StudentAppstatus { get; set; }
        public virtual string StudentValid { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string StudentHasapp { get; set; }
        public virtual string StudentApproveby { get; set; }
        public virtual string StudentGcmtoken { get; set; }
        public virtual string StudentLogintoken { get; set; }
    }
}
