using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
    
    public class TblTeacher {
        public virtual int TeacherId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets Allowed")]
        [MaxLength(10, ErrorMessage = "Max. length should be 10 character")]
        [MinLength(2, ErrorMessage = "Min. length should be 2 character")]
        public virtual string TeacherFirstname { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets Allowed")]
        [MaxLength(10, ErrorMessage = "Max. length should be 10 character")]
        [MinLength(2, ErrorMessage = "Min. length should be 2 character")]
        public virtual string TeacherLastname { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public virtual string TeacherGender { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "DOB is Required")]
        public virtual DateTime? TeacherDob { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        public virtual string TeacherEmail { get; set; }
        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile Number is Required")]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = "Only Mobile Number")]
        public virtual string TeacherPhonenumber { get; set; }
        [Display(Name = "Address")]
        public virtual string TeacherAddress { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int? DepartmentId { get; set; }
        [Display(Name = "Profile Image")]
        public virtual string TeacherImage { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(10, ErrorMessage = "Max. length should be 7 character")]
        [MinLength(2, ErrorMessage = "Min. length should be 4 character")]
        public virtual string TeacherUserName { get; set; }
        [Display(Name = "Password")]
        [MaxLength(10, ErrorMessage = "Max. length should be 10")]
        [MinLength(5, ErrorMessage = "Mini. length should be 5")]
        [Required(ErrorMessage = "Password must be required")]
        [DataType(DataType.Password)]
        public virtual string TeacherPassword { get; set; }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Required")]
        public virtual string TeacherDesignation { get; set; }
        [Display(Name = "Job Status")]
        [Required(ErrorMessage = "Required")]
        public virtual string TeacherJobStatus { get; set; }
        [Display(Name = "Are You HOD")]
        public virtual string TeacherIsHOD { get; set; }
        public virtual string TeacherAppStatus { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string TeacherValid { get; set; }
        public virtual string TeacherHasApp { get; set; }
        public virtual string TeacherApproveBy { get; set; }
        public virtual int? TeacherFollowers { get; set; }
        public virtual string TeachergcmToken { get; set; }
        public virtual string TeacherLoginToken { get; set; }
    }
}
