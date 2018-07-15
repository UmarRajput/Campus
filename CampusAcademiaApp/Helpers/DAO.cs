using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
namespace CampusAcademiaApp
{
    public class DAO
    {
        private ISession NHSession = null;
        public DAO(ISession S)
        {
            NHSession = S;
        }
        public string encode(string data,int length)
        {
            string password =data;
            string s1 = password.Substring(0,3);
            string s2 = password.Substring(3,2);
            string s3 = password.Substring(5,length-5);
            
            byte[] bytearray = System.Text.ASCIIEncoding.ASCII.GetBytes("@@@" + s1 + "&&&" + s2 + "((("+s3+"$$$");
            string s = System.Convert.ToBase64String(bytearray);
            return s;
        }
        public string decode(string data)
        {
            byte[] bytearray2 = System.Convert.FromBase64String(data);

            string s3 = System.Text.ASCIIEncoding.ASCII.GetString(bytearray2);

            string withoutsalt = s3.Replace("@@@", "").Replace("(((", "").Replace("&&&", "").Replace("$$$","");

            return withoutsalt;
        }
        #region Admin
        public TblAdmin adminLogin(string user,string password)
        {
            TblAdmin obj = (TblAdmin)NHSession.CreateCriteria(typeof(TblAdmin))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.AdminUsername,user))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.AdminPassword,password))
                                  .UniqueResult();
            return obj;
        }
        public bool sentAdminToDB(TblAdmin admin)
        {
            bool result = false;
        using(ITransaction T=NHSession.BeginTransaction())
        {
            try
            {
                NHSession.SaveOrUpdate(admin);
                T.Commit();
                result = true;
            }
            catch(Exception ex)
            {
                T.Rollback();
            }
        }
        return result;
     }
        public IList<TblAdmin> adminList()
        {
            IList<TblAdmin> list = NHSession.CreateCriteria(typeof(TblAdmin)).List<TblAdmin>();
            foreach (var dec in list)
            {
                dec.AdminPassword =decode(dec.AdminPassword);
                dec.AdminPhonenumber = decode(dec.AdminPhonenumber);
            }
            return list;
        }
        public TblAdmin getAdmin(int id)
        {
            TblAdmin obj = (TblAdmin)NHSession.CreateCriteria(typeof(TblAdmin))
                         .Add(Restrictions.Eq(Constants.allModelProperties.AdminId, id))
                         .UniqueResult();
            obj.AdminPassword = decode(obj.AdminPassword);
            obj.AdminPhonenumber = decode(obj.AdminPhonenumber);
            return obj;
        
        }
        public bool deleteAdmin(TblAdmin A)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(A);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        } 
        public object[] login(string email,string pwd)
        {
            object[] obj = (object[])NHSession.CreateCriteria(typeof(TblAdmin))
                         .Add(Restrictions.Eq("AdminEmail", email))
                         .Add(Restrictions.Eq("AdminPassword", pwd))
                         .SetProjection(Projections.ProjectionList()
                         .Add(Projections.Property("AdminEmail"))
                         .Add(Projections.Property("AdminPassword"))
                         ).UniqueResult();
            return obj;
        }
        public string checkAdminUserName(string username)
        {
            string adminusername = (string)NHSession
                           .CreateCriteria(typeof(TblAdmin))
                           .Add(Restrictions.Eq(Constants.allModelProperties.AdminUsername, username))
                           .SetProjection(Projections.ProjectionList().Add(Projections.Property(Constants.allModelProperties.AdminUsername)))
                           .UniqueResult();

            return adminusername;
        }
        #region Department
        public bool AddDepartment(TblDepartment D)
        {
            bool result = false;
            using(ITransaction T=NHSession.BeginTransaction())
            {
                try 
                {
                    NHSession.SaveOrUpdate(D);
                    T.Commit();
                    result = true;
                }
                catch(Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblDepartment> ListDepartments()
        {
            IList<TblDepartment> list=NHSession.CreateCriteria(typeof(TblDepartment))
                                    .List<TblDepartment>();
            return list;
        }
        public TblDepartment getDepartment(int givenID)
        {
            TblDepartment tdObj =(TblDepartment) NHSession.CreateCriteria(typeof(TblDepartment))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.DeptId, givenID))
                                         .UniqueResult();
            return tdObj;
        }
        public bool deleteDepartment(TblDepartment D)
        {
            bool result = false;
            using(ITransaction T=NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(D);
                    T.Commit();
                    result = true;
                }
                catch(Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion
        #region Course
        public bool AddCourse(TblCourse course)
        {
            bool result = false;
            using(ITransaction T=NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(course);
                    T.Commit();
                    result = true;
                }
                catch(Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<DeptCourseView> ListCourse()
        {
            IList<DeptCourseView> list=NHSession.CreateCriteria(typeof(DeptCourseView)).List<DeptCourseView>();
            return list;
        }
        public TblCourse getCourse(int givenID)
        {
            TblCourse _objCourse = (TblCourse)NHSession.CreateCriteria(typeof(TblCourse))
                                   .Add(Restrictions.Eq(Constants.allModelProperties.CourseId, givenID))
                                   .UniqueResult();
            return _objCourse;
        }
        public bool DeleteCourse(TblCourse course)
        {
            bool result = false;
            using(ITransaction T=NHSession.BeginTransaction())
            {
                try 
                    {
                        NHSession.Delete(course);
                        T.Commit();
                        result = true;
                     }
                catch(Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblCourse> getDepartmentCourse(int givenID)
        {
            IList<TblCourse> list = NHSession.CreateCriteria(typeof(TblCourse))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.DeptId, givenID))
                                  .List<TblCourse>();
            return list;
        }
        #endregion
        #region Subject
        public bool AddSubject(TblSubject subject)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(subject);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<DeptSubjectView> getAllSubjects()
        {
            IList<DeptSubjectView> list = NHSession.CreateCriteria(typeof(DeptSubjectView)).AddOrder(Order.Desc(Constants.allModelProperties.SubjectId)).List<DeptSubjectView>();
            return list;
        }
        public TblSubject getSubject(int givenID)
        {
            TblSubject tdObj = (TblSubject)NHSession.CreateCriteria(typeof(TblSubject))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.SubjectId, givenID))
                                         .UniqueResult();
            return tdObj;
        }
        public bool deleteSubject(TblSubject s)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(s);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion
        #region Session
        public bool addSession(TblSession session)
        {
            bool result = false;
            using(ITransaction T=NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(session);
                    T.Commit();
                    result = true;
                }
                catch(Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<DeptCourseSession> sessionList()
        {
            IList<DeptCourseSession> list = NHSession.CreateCriteria(typeof(DeptCourseSession))
                                            .AddOrder(Order.Desc(Constants.allModelProperties.SessionId))
                                            .List<DeptCourseSession>();
            return list;
        }
        public TblSession getSession(int id)
        {
            TblSession obj =(TblSession) NHSession.CreateCriteria(typeof(TblSession))
                                     .Add(Restrictions.Eq(Constants.allModelProperties.SessionId, id))
                                     .UniqueResult();
            return obj;
        }
        public bool DeleteSession(TblSession session)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(session);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        } 
        #endregion

        #region Upload Book
        public bool uploadBook(TblBooks book)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(book);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<Library> booklist()
        {
            IList<Library> list = NHSession.CreateCriteria(typeof(Library))
                .AddOrder(Order.Desc(Constants.allModelProperties.BookId))
                .List<Library>();
            return list;
        }
        public TblBooks getBook(int id)
        {
            TblBooks obj = (TblBooks)NHSession.CreateCriteria(typeof(TblBooks))
                         .Add(Restrictions.Eq(Constants.allModelProperties.BookId,id))
                         .UniqueResult();
            return obj;
        }
        public bool DeleteBook(TblBooks book)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(book);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion

        #region Teacher
        public bool signupTeacher(TblTeacher teacher)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(teacher);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TeacherProfileView> ListTeacher()
        {
            IList<TeacherProfileView> list = NHSession.CreateCriteria(typeof(TeacherProfileView))
                                            //.Add(Restrictions.Eq(Constants.allModelProperties.TeacherValid,Constants.allModelProperties.Approve))
                                            .AddOrder(Order.Desc(Constants.allModelProperties.TeacherId))
                                            .List<TeacherProfileView>();
            return list;
        }
        public TblTeacher getTeacher(int givenID)
        {
            TblTeacher _objTeacher = (TblTeacher)NHSession.CreateCriteria(typeof(TblTeacher))
                                   .Add(Restrictions.Eq(Constants.allModelProperties.TeacherId, givenID))
                                   .UniqueResult();
            return _objTeacher; 
        }
        public bool DeleteTeacher(TblTeacher teacher)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(teacher);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public string checkteacherUserName(string username)
        {
            string teacherusername = (string)NHSession
                           .CreateCriteria(typeof(TblTeacher))
                           .Add(Restrictions.Eq(Constants.allModelProperties.TeacherUserName, username))
                           .SetProjection(Projections.ProjectionList().Add(Projections.Property(Constants.allModelProperties.TeacherUserName)))
                           .UniqueResult();

            return teacherusername;
        }
        #endregion

        #region Faculty
        public bool createFaculty(TblFaculty faculty)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(faculty);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        //public IList<DeptCourseView> ListCourse()
        //{
        //    IList<DeptCourseView> list = NHSession.CreateCriteria(typeof(DeptCourseView)).AddOrder(Order.Desc(Constants.allModelProperties.CourseId)).List<DeptCourseView>();
        //    return list;
        //}
        #endregion

        #region News
        public bool addNews(TblNews news)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(news);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblNews> newsList()
        {
            IList<TblNews> list = NHSession.CreateCriteria(typeof(TblNews)).AddOrder(Order.Desc(Constants.allModelProperties.NewsId)).List<TblNews>();
            return list;
        }
        public TblNews getNews(int givenID)
        {
            TblNews _objCourse = (TblNews)NHSession.CreateCriteria(typeof(TblNews))
                                   .Add(Restrictions.Eq(Constants.allModelProperties.NewsId, givenID))
                                   .UniqueResult();
            return _objCourse;
        }
        public bool DeleteNews(TblNews news)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(news);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion

        #region Events
        public bool addEvents(TblEvents E)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(E);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblEvents> eventList()
        {
            IList<TblEvents> list = NHSession.CreateCriteria(typeof(TblEvents)).AddOrder(Order.Desc(Constants.allModelProperties.EventId)).List<TblEvents>();
            return list;
        }
        public TblEvents getEvent(int givenID)
        {
            TblEvents _objCourse = (TblEvents)NHSession.CreateCriteria(typeof(TblEvents))
                                   .Add(Restrictions.Eq(Constants.allModelProperties.EventId, givenID))
                                   .UniqueResult();
            return _objCourse;
        }
        public bool DeleteEvent(TblEvents E)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(E);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion

        #region Notes

        /*This list is used in Notes view when user select dept from dept dropdown then department subject
        
        is loaded in Subject dropdown */
        public IList<TblSubject> getDepartmentSubjects(int givenID)
        {
            IList<TblSubject> list = NHSession.CreateCriteria(typeof(TblSubject))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.DeptId, givenID))
                                  .List<TblSubject>();
            return list;
        }
        public bool uploadNotes(TblNotes notes)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(notes);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblNotes> noteslist()
        {
            IList<TblNotes> list = NHSession.CreateCriteria(typeof(TblNotes)).AddOrder(Order.Desc(Constants.allModelProperties.NotesId)).List<TblNotes>();
            return list;
        }
        public TblNotes getNotes(int id)
        {
            TblNotes obj = (TblNotes)NHSession.CreateCriteria(typeof(TblNotes))
                         .Add(Restrictions.Eq(Constants.allModelProperties.NotesId, id))
                         .UniqueResult();
            return obj;
        }
        public bool DeleteNotes(TblNotes notes)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(notes);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion

        #region Student
        public bool signupStudent(TblStudent student)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(student);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblStudent> ListStudents()
        {
            IList<TblStudent> list = NHSession.CreateCriteria(typeof(TblStudent))
                //.Add(Restrictions.Eq(Constants.allModelProperties.TeacherValid,Constants.allModelProperties.Approve))
                                            .AddOrder(Order.Desc(Constants.allModelProperties.StudentId))
                                            .List<TblStudent>();
            return list;
        }
        public TblStudent getStudent(int givenID)
        {
            TblStudent objStudent = (TblStudent)NHSession.CreateCriteria(typeof(TblStudent))
                                   .Add(Restrictions.Eq(Constants.allModelProperties.StudentId, givenID))
                                   .UniqueResult();
            return objStudent;
        }
        public bool DeleteStudent(TblStudent student)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(student);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public string checkStudentRollNumber(string RN)
        {
            string studentID = (string)NHSession
                           .CreateCriteria(typeof(TblStudent))
                           .Add(Restrictions.Eq(Constants.allModelProperties.StudentRollnumber, RN))
                           .SetProjection(Projections.ProjectionList().Add(Projections.Property(Constants.allModelProperties.StudentRollnumber)))
                           .UniqueResult();

            return studentID;
        }
        public IList<TblSession> getDepartmentCourseSession(int CourseID,int DeptID)
        {
            IList<TblSession> list = NHSession.CreateCriteria(typeof(TblSession))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.DeptId, DeptID))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.CourseId, CourseID))
                                  .List<TblSession>();
            return list;
        }
         public string getCourseSessionSection(int CourseID,int DeptID,int SessionId)
        {
                  string section   = NHSession.CreateCriteria(typeof(TblSession))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.DeptId, DeptID))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.CourseId, CourseID))
                                  .Add(Restrictions.Eq(Constants.allModelProperties.SessionId, SessionId))
                                  .SetProjection(Projections.ProjectionList().Add(Projections.Property(Constants.allModelProperties.SessionSections)))
                                  .UniqueResult().ToString();
                  return section;
        }
        #endregion

        #region Gallery
        public int AddEventName(TblPhotofoldername fn)
        {
            
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    int eventNameID = (Int32)NHSession.Save(fn);
                    T.Commit();
                    return eventNameID;
                    
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return -1;
        }
        public IList<TblPhotofoldername> eventNameList()
        {
            IList<TblPhotofoldername> list = NHSession.CreateCriteria(typeof(TblPhotofoldername))
                                       .List<TblPhotofoldername>();
            return list;
        }
        public TblPhotofoldername getFNd(int id)
        {
            TblPhotofoldername obj =(TblPhotofoldername) NHSession.CreateCriteria(typeof(TblPhotofoldername))
                         .Add(Restrictions.Eq(Constants.allModelProperties.PhotofoldernameId, id))
                         .UniqueResult();
            return obj;

        }
        public bool AddImagesInGallery(TblPhotogallery pg)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(pg);
                    T.Commit();
                    result = true;

                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion


        #region addDayTime
        public bool AddTime(TblLecturetime L)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(L);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblLecturetime> ListDayTime()
        {
            IList<TblLecturetime> list = NHSession.CreateCriteria(typeof(TblLecturetime))
                                    .AddOrder(Order.Asc(Constants.allModelProperties.LecturetimeTime))
                                   // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<TblLecturetime>();
            return list;
        }
        public TblLecturetime getDayTime(int givenID)
        {
            TblLecturetime tdObj = (TblLecturetime)NHSession.CreateCriteria(typeof(TblLecturetime))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.LecturetimeId, givenID))
                                         .UniqueResult();
            return tdObj;
        }
        public bool deleteDayTime(TblLecturetime L)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(L);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion

        #region Add Time Table
        public int AddTimeTable(TblTimetable Tb)
        {
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    int result=(Int32)NHSession.Save(Tb);
                    T.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return -1;
        }
        public IList<TimeTableSessionView> ListTimeTable()
        {
            IList<TimeTableSessionView> list = NHSession.CreateCriteria(typeof(TimeTableSessionView))
                                   .AddOrder(Order.Desc(Constants.allModelProperties.TimetableId))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<TimeTableSessionView>();
            return list;
        }
        //List Search Time Table
        public IList<TimeTableSessionView> ListTimeTable(string idd,string idc)
        {
            IList<TimeTableSessionView> list = NHSession.CreateCriteria(typeof(TimeTableSessionView))
                .Add(Restrictions.Eq(Constants.allModelProperties.DeptName, idd))
                .Add(Restrictions.Eq(Constants.allModelProperties.CourseCode, idc))
                                   .AddOrder(Order.Desc(Constants.allModelProperties.TimetableId))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<TimeTableSessionView>();
            return list;
        }

        //Get TimeTable For checking Already Exist
        public TblTimetable getTimeTable(int DeptID,int courseID,int sessionID,string section)
        {
            var dis = Restrictions.Disjunction();
            TblTimetable tdObj = (TblTimetable)NHSession.CreateCriteria(typeof(TblTimetable))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.DeptId, DeptID))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.CourseId, courseID))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.SessionId, sessionID))
                                         .Add(dis.Add(Restrictions.Eq(Constants.allModelProperties.ClassSection, section)))
                                         .UniqueResult();
            return tdObj;
        }
        //Get TimeTable Model For Delete
        public TblTimetable getTimeTable(int givenID)
        {
            TblTimetable tdObj = (TblTimetable)NHSession.CreateCriteria(typeof(TblTimetable))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.TimetableId, givenID))
                                         .UniqueResult();
            return tdObj;
        }
        public bool deleteTimeTable(TblTimetable L)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(L);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<MrngEveScheduleView> TimeTableSchedule()
        {
            IList<MrngEveScheduleView> list = NHSession.CreateCriteria(typeof(MrngEveScheduleView))
                //.Add(Restrictions.Eq(Constants.allModelProperties.,id))
                // .AddOrder(Order.Asc(Constants.allModelProperties))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<MrngEveScheduleView>();
            return list;
        }
        #endregion
        #region Add Time Table Detail Morning
        public bool AddTimeTableMorning(TblMorningtime Tbm)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(Tbm);
                    T.Commit();
                    result=true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<MorningScheduleView> ListMorningSchedule()
        {
            IList<MorningScheduleView> list = NHSession.CreateCriteria(typeof(MorningScheduleView))
                                        //.Add(Restrictions.Eq(Constants.allModelProperties.TimetableId,id))
                                  //  .AddOrder(Order.Asc(Constants.allModelProperties.LecturetimeTime))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<MorningScheduleView>();
            return list;
        }
        //List For Morning Time Delete 
        public IList<TblMorningtime> ListMorningDelete(int id)
        {
            IList<TblMorningtime> list = NHSession.CreateCriteria(typeof(TblMorningtime))
                                 .Add(Restrictions.Eq(Constants.allModelProperties.TimetableId,id))
                //  .AddOrder(Order.Asc(Constants.allModelProperties.LecturetimeTime))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<TblMorningtime>();
            return list;
        }
        //public TblLecturetime getTimeTable(int givenID)
        //{
        //    TblLecturetime tdObj = (TblLecturetime)NHSession.CreateCriteria(typeof(TblLecturetime))
        //                                 .Add(Restrictions.Eq(Constants.allModelProperties.LecturetimeId, givenID))
        //                                 .UniqueResult();
        //    return tdObj;
        //}
        //public bool deleteTimeTable(TblLecturetime L)
        //{
        //    bool result = false;
        //    using (ITransaction T = NHSession.BeginTransaction())
        //    {
        //        try
        //        {
        //            NHSession.Delete(L);
        //            T.Commit();
        //            result = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            T.Rollback();
        //        }
        //    }
        //    return result;
        //}
        public TblMorningtime getMorningSchedule(int givenID)
        {
            TblMorningtime tdObj = (TblMorningtime)NHSession.CreateCriteria(typeof(TblMorningtime))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.MorningtimeId, givenID))
                                         .UniqueResult();
            return tdObj;
        }
        public bool deleteMorningSchedule(TblMorningtime mt)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(mt);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<TblSubject> getAllDeptSubjects(int givenid)
        {
            IList<TblSubject> list = NHSession.CreateCriteria(typeof(TblSubject))
                                    .Add(Restrictions.Eq(Constants.allModelProperties.DeptId,givenid))
                                    .AddOrder(Order.Desc(Constants.allModelProperties.SubjectTitle))
                                    .List<TblSubject>();
            return list;
        }
        #endregion

        #region Add Time Table Detail Evening
        public bool AddTimeTableEvening(TblEveningtime Tbe)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.SaveOrUpdate(Tbe);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        public IList<EveningScheduleView> ListEveningSchedule()
        {
            IList<EveningScheduleView> list = NHSession.CreateCriteria(typeof(EveningScheduleView))
                                       // .Add(Restrictions.Eq(Constants.allModelProperties.TimetableId, id))
                //  .AddOrder(Order.Asc(Constants.allModelProperties.LecturetimeTime))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<EveningScheduleView>();
            return list;
        }
        //List For Evening Time Delete 
        public IList<TblEveningtime> ListEveningDelete(int id)
        {
            IList<TblEveningtime> list = NHSession.CreateCriteria(typeof(TblEveningtime))
                                 .Add(Restrictions.Eq(Constants.allModelProperties.TimetableId, id))
                //  .AddOrder(Order.Asc(Constants.allModelProperties.LecturetimeTime))
                // .Add(Expression.Like(Constants.allModelProperties.LecturetimeTime,"AM",MatchMode.End))
                                    .List<TblEveningtime>();
            return list;
        }
        //public TblLecturetime getTimeTable(int givenID)
        //{
        //    TblLecturetime tdObj = (TblLecturetime)NHSession.CreateCriteria(typeof(TblLecturetime))
        //                                 .Add(Restrictions.Eq(Constants.allModelProperties.LecturetimeId, givenID))
        //                                 .UniqueResult();
        //    return tdObj;
        //}
        //public bool deleteTimeTable(TblLecturetime L)
        //{
        //    bool result = false;
        //    using (ITransaction T = NHSession.BeginTransaction())
        //    {
        //        try
        //        {
        //            NHSession.Delete(L);
        //            T.Commit();
        //            result = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            T.Rollback();
        //        }
        //    }
        //    return result;
        //}
        public TblEveningtime getEveningSchedule(int givenID)
        {
            TblEveningtime tdObj = (TblEveningtime)NHSession.CreateCriteria(typeof(TblEveningtime))
                                         .Add(Restrictions.Eq(Constants.allModelProperties.EveningtimeId, givenID))
                                         .UniqueResult();
            return tdObj;
        }
        public bool deleteEveningSchedule(TblEveningtime et)
        {
            bool result = false;
            using (ITransaction T = NHSession.BeginTransaction())
            {
                try
                {
                    NHSession.Delete(et);
                    T.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    T.Rollback();
                }
            }
            return result;
        }
        #endregion
        #endregion
    }
}