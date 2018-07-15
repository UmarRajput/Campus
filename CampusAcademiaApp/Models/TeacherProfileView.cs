using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CampusAcademiaApp
{
    public class TeacherProfileView
    {
        public virtual int TeacherId { get; set; }
        [Display(Name = "First Name")]
        public virtual string TeacherFirstname { get; set; }
        [Display(Name = "Last Name")]
        public virtual string TeacherLastname { get; set; }
        [Display(Name = "Gender")]
        public virtual string TeacherGender { get; set; }
        [Display(Name = "Date Of Birth")]
        public virtual DateTime? TeacherDob { get; set; }
        [Display(Name = "Email")]
        public virtual string TeacherEmail { get; set; }
        [Display(Name = "Mobile")]
        public virtual string TeacherPhonenumber { get; set; }
        [Display(Name = "Address")]
        public virtual string TeacherAddress { get; set; }
        [Display(Name = "Department")]
        public virtual string DepartmentName { get; set; }
        [Display(Name = "Profile Image")]
        public virtual string TeacherImage { get; set; }
        [Display(Name = "User Name")]
        public virtual string TeacherUserName { get; set; }
        [Display(Name = "Password")]
        public virtual string TeacherPassword { get; set; }
        [Display(Name = "Designation")]
        public virtual string TeacherDesignation { get; set; }
        [Display(Name = "Job Status")]
        public virtual string TeacherJobStatus { get; set; }
        [Display(Name = "Are You HOD")]
        public virtual string TeacherIsHOD { get; set; }
        [Display(Name = "App Status")]
        public virtual string TeacherAppStatus { get; set; }
        [Display(Name = "Last Modify Date")]
        public virtual DateTime? ModifyDate { get; set; }
        [Display(Name = "Created Date")]
        public virtual DateTime? CreatedDate { get; set; }
        [Display(Name = "Using App")]
        public virtual string TeacherHasApp { get; set; }
        [Display(Name = "Your Followers")]
        public virtual int? TeacherFollowers { get; set; }
        [Display(Name = "Valid")]
        public virtual string TeacherValid { get; set; }
        [Display(Name = "Approve By")]
        public virtual string TeacherApproveBy { get; set; }
    }
}