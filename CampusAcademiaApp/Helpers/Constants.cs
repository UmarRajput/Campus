using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAcademiaApp
{
    public static class Constants
    {
        public struct allModelProperties
        {
            public const string registrationMessage = "Record Successfully Added!";
            public const string UpdateMessage = "Record Update Successfully!";
            public const string DeleteMessage = "Record Delete Successfully!";
            public const string MessagetypeSuccess = "Success";
            public const string MessageTypeDelete = "Success";
            public const string ScheduleExist = "You Cannot Create Time Table Because Already Exist First You Need Delete That !";

            public const string MessageTypeError = "Error";

            public const string SuperAdminType = "Super Admin";
            public const string AdminType = "Admin";
            public const string AppStatus = "Hey there! I am using AcademiaApp.";
            public const string Approve = "Approve";
            public const string UnAprove = "UnAprove";
            public const string IsAppActive = "Yes";
            public const string IsAppNon = "NO";
            public const string LoadingIcon = "~/Uploads/Icons/LoadingCircle.gif";
            public const string GreenTickIcon = "~/Uploads/Icons/green-tick.png";

            //Dept means Department
            public const string DeptId = "DepartmentId";
            public const string DeptName = "DepartmentName";
            public const string DeptCode = "DepartmentCode";

            //Course
            public const string CourseId = "CourseId";
            public const string CourseName = "CourseName";
            public const string CourseCode = "CourseCode";

            //subject
            public const string SubjectId = "SubjectId";
            public const string SubjectTitle = "SubjectTitle";
            public const string SubjectCode = "SubjectCode";
            public const string SubjectCredithour = "SubjectCredithour";

            //Session
            public const string SessionId = "SessionId";
            public const string SessionStart = "SessionStart";
            public const string SessionEnd = "SessionEnd";
            public const string SessionSections = "SessionSections";
            public const string SessionCreateddate = "SessionCreateddate";

            //Books

            public const string BookId = "BookId";
            public const string BookTitle = "BookTitle";
            public const string BookAuthor = "BookAuthor";
            public const string File = "File";
            public const string BookDownloads = "BookDownloads";

            //News
            public const string NewsId = "NewsId";
            public const string NewsDescription = "NewsDescription";
            public const string PostedDate = "PostedDate";
            public const string PostedBy = "PostedBy";

            //Events
            public const string EventId = "EventId";
            public const string EventTitle = "EventTitle";
            public const string EventDescription = "EventDescription";
            public const string EventDate = "EventDate";
            //public const string PostedDate = "PostedDate";
            //public const string PostedBy = "PostedBy";
            
            //Notes

            public const string NotesId = "NotesId";
            public const string NotesTopicname = "NotesTopicname";
            public const string UpdatedNotes = "UpdatedNotes";
            public const string NotesPosteddate = "NotesPosteddate";
           
            //Teacher
            public const string TeacherId = "TeacherId";
            public const string TeacherFirstname = "TeacherFirstname";
            public const string TeacherLastname = "TeacherLastname";
            public const string TeacherGender = "TeacherGender";
            public const string TeacherDob = "TeacherDob";
            public const string TeacherEmail = "TeacherEmail";
            public const string TeacherPhonenumber = "TeacherPhonenumber";
            public const string TeacherAddress = "TeacherAddress";
            public const string TeacherImage = "TeacherImage";
            public const string TeacherPassword = "TeacherPassword";
            public const string ModifyDate = "ModifyDate";
            public const string TeacherUserName = "TeacherUserName";
            public const string TeacherDesignation = "TeacherDesignation";
            public const string TeacherJobStatus = "TeacherJobStatus";
            public const string TeacherIsHOD = "TeacherIsHOD";
            public const string CreatedDate = "CreatedDate";
            public const string TeacherValid = "TeacherValid";
            public const string Teacher_AppStatus = "Teacher_AppStatus";
            public const string TeacherHasApp = "TeacherHasApp";


            //Student

            public const string StudentId = "StudentId";
            public const string StudentRollnumber = "StudentRollnumber";
            public const string StudentName = "StudentName";
            public const string StudentGender = "StudentGender";
            public const string StudentDob = "StudentDob";
            public const string StudentEmail = "StudentEmail";
            public const string StudentPhonenumber = "StudentPhonenumber";
            public const string StudentSection = "StudentSection";
            public const string StudentClasstime = "StudentClasstime";
            public const string StudentPassword = "StudentPassword";
            public const string StudentValid = "StudentValid";
            public const string StudentAppstatus = "StudentAppstatus";
            public const string StudentHasapp = "StudentHasapp";

            //Admin
            public const string AdminId = "AdminId";
            public const string AdminName = "AdminName";
            public const string AdminGender = "AdminGender";
            public const string AdminDob = "AdminDob";
            public const string AdminEmail = "AdminEmail";
            public const string AdminPhonenumber = "AdminPhonenumber";
            public const string AdminUsername = "AdminUsername";
            public const string AdminPassword = "AdminPassword";
            public const string AdminImage = "AdminImage";
            public const string AdminUsertype = "AdminUsertype";
            public const string CreatedBy = "CreatedBy";

            // TblPhotoFolderName
            public const string PhotofoldernameId = "PhotofoldernameId";
            public const string FolderName = "FolderName";
            //TblPhotoGallery
            public const string PhotogalleryId = "PhotogalleryId";

            //TbllectureTime
            public const string LecturetimeId = "LecturetimeId";
            public const string LecturetimeTime = "LecturetimeTime";

            //TblTimeTable
            public const string TimetableId = "TimetableId";
            public const string ClassSection = "ClassSection";


            //TblMorningTimeTable
            public const string MorningtimeId = "MorningtimeId";

            //TblEveningTimeTable
            public const string EveningtimeId = "EveningtimeId";

        }
    }
}