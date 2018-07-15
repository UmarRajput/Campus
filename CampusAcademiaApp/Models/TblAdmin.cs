using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {
     
    public class TblAdmin {
        public virtual int AdminId { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets Allowed")]
        [MaxLength(25, ErrorMessage = "Max. Length should be 25")]
        [MinLength(3, ErrorMessage = "Min. Length should be 3")]
        public virtual string AdminName { get; set; }
        [Display(Name = "Gender")]
        public virtual string AdminGender { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Required")]
        public virtual DateTime? AdminDob { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[_]*([a-z0-9]+(\.|_*)?)+@([a-z][a-z0-9-]+(\.|-*\.))+[a-z]{2,6}$", ErrorMessage = "Only Alphabets Allowed")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not Valid")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string AdminEmail { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Numbers Allowed")]
        [MaxLength(11, ErrorMessage = "Enter Valid Mobile Number of Length 11")]
        [MinLength(11, ErrorMessage = "Enter Valid Mobile Number of Length 11")]
        //[DataType(DataType.PhoneNumber,ErrorMessage="Not Valid Phone Number Format")]
        public virtual string AdminPhonenumber { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special Charcater not Allowed")]
        [MaxLength(7, ErrorMessage = "Max. Length should be 7")]
        [MinLength(3, ErrorMessage = "Min. Length should be 3")]
        public virtual string AdminUsername { get; set; }
        [Display(Name = "Password")]
        [MaxLength(10, ErrorMessage = "Max. Length should be 10")]
        [MinLength(5, ErrorMessage = "Mini. Length should be 5")]
        [Required(ErrorMessage = "Password must be Required")]
        [DataType(DataType.Password)]
        public virtual string AdminPassword { get; set; }
        [Display(Name = "Profile Image")]
        public virtual string AdminImage { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required")]
        public virtual int? DepartmentId { get; set; }
        [Display(Name = "User Type")]
        public virtual string AdminUsertype { get; set; }
        public virtual string AdminValid { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}
