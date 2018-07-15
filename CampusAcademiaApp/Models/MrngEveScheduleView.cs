using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CampusAcademiaApp
{
    public class MrngEveScheduleView
    {
        public virtual int TimetableId { get; set; }
        [Display(Name = "First Day")]
        public virtual string MorningtimeDay1 { get; set; }
        [Display(Name = "Start Time")]
        public virtual string MorningtimeDay1startlec { get; set; }
        [Display(Name = "End Time")]
        public virtual string MorningtimeDay1endlec { get; set; }
        [Display(Name = "Second Day")]
        public virtual string MorningtimeDay2 { get; set; }
        [Display(Name = "Start Time")]
        public virtual string MorningtimeDay2startlec { get; set; }
        [Display(Name = "End Time")]
        public virtual string MorningtimeDay2endlec { get; set; }
        [Display(Name = "Name of The Teacher")]
        public virtual string TeacherFirstname { get; set; }
        [Display(Name = "Last Name")]
        public virtual string TeacherLastname { get; set; }
        [Display(Name = "Subject Title")]
        public virtual string SubjectTitle { get; set; }
        [Display(Name = "Subject Code")]
        public virtual string SubjectCode { get; set; }
        [Display(Name = "Credit Hour")]
        public virtual int SubjectCredithour { get; set; }
        [Display(Name = "Session Start")]
        public virtual string SessionStart { get; set; }
        [Display(Name = "Session End")]
        public virtual string SessionEnd { get; set; }
        [Display(Name = "Class Section")]
        public virtual string ClassSection { get; set; }
        [Display(Name = "Course Name")]
        public virtual string CourseName { get; set; }
        [Display(Name = "Course Code")]
        public virtual string CourseCode { get; set; }
        [Display(Name = "Department Name")]
        public virtual string DepartmentName { get; set; }
        [Display(Name = "Department Code")]
        public virtual string DepartmentCode { get; set; }
        [Display(Name = "First Day")]
        public virtual string EveningtimeDay1 { get; set; }
        [Display(Name = "Start Time ")]
        public virtual string EveningtimeDay1startlec { get; set; }
        [Display(Name = "End Time")]
        public virtual string EveningtimeDay1endlec { get; set; }
        [Display(Name = "Second Day")]
        public virtual string EveningtimeDay2 { get; set; }
        [Display(Name = "Start Time")]
        public virtual string EveningtimeDay2startlec { get; set; }
        [Display(Name = "End Time")]
        public virtual string EveningtimeDay2endlec { get; set; }

        //public override bool Equals(object obj)
        //{
        //    MrngEveScheduleView toCompare = obj as MrngEveScheduleView;
        //    if (toCompare == null)
        //    {
        //        return false;
        //    }

        //    if (!Object.Equals(this.MorningtimeId, toCompare.MorningtimeId))
        //        return false;
        //    if (!Object.Equals(this.EveningtimeId, toCompare.EveningtimeId))
        //        return false;

        //    return true;
        //}
        //public override int GetHashCode()
        //{
        //    int hashCode = 13;
        //    hashCode = (hashCode * 7) + MorningtimeId.GetHashCode();
        //    hashCode = (hashCode * 7) + EveningtimeId.GetHashCode();
        //    //hashCode = (hashCode * 7) + RatingId.GetHashCode();
        //    return hashCode;
        //}
    }
}