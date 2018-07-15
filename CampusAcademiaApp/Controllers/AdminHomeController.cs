using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
namespace CampusAcademiaApp.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /AdminHome/

        #region Admin
        public ActionResult welcome()
        {
            if (Session["AdminUser"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "AdminHome");
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string user, string password)
        {
            if (user != "" && password != "")
            {
                DAO oDAO = new DAO(MvcApplication.SF.OpenSession());
                TblAdmin obj = oDAO.adminLogin(user, password);
                if (obj != null)
                {  
                        Session["AdminUser"] = obj;
                        return RedirectToAction("welcome", "AdminHome");
                }   
            }
            return View();
        }
        public ActionResult AdminLogout()
        {
            Session.Remove("AdminUser");
            return RedirectToAction("AdminLogin", "AdminHome");
        }
        public string checkAdminUserName(string username)
        {
            if (username != "")
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                string name = oDAO.checkAdminUserName(username);
                if (name != null)
                {
                    return name;
                }
                else
                {
                    return name;
                }
            }
            else
            {
                string name = "Required";
                return name;
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email !="" && password !="")
            {
                DAO oDAO = new DAO(MvcApplication.SF.OpenSession());
                object[] login = oDAO.login(email, password);
                string email1 = login[0].ToString();
                string pwd1 = login[1].ToString();
                if (email == email1 && password == pwd1)
                {
                    return RedirectToAction("AllDepartments", "AdminHome");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult createAdmin()
        {
          //  TblAdmin obj = (TblAdmin)Session["AdminUser"];
            //if (obj.AdminUsertype == Constants.allModelProperties.SuperAdminType)
            //{
                return View();
           // }
            //return RedirectToAction("welcome", "AdminHome");
        }
        [HttpPost]
        public ActionResult createAdmin(TblAdmin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (string upload in Request.Files)
                    {
                        if (Request.Files[upload].ContentLength > 0)
                        {
                            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                            if (!Directory.Exists(RootFolder + "AdminImage/"))
                            {
                                Directory.CreateDirectory(RootFolder + "AdminImage/");

                            }
                            string path = RootFolder + "AdminImage/";
                            string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                            string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                            string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                            admin.AdminImage = newfilename;
                            Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                        }
                        else
                        {
                            admin.AdminImage = "profile-image.jpg";
                        }
                    }

                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    admin.CreatedDate = DateTime.Now;
                    admin.ModifyDate = DateTime.Now;
                    admin.CreatedBy = "Super Admin";
                    admin.AdminValid = Constants.allModelProperties.Approve;
                    string pwd= oDAO.encode(admin.AdminPassword, admin.AdminPassword.Length);
                    string mobNo = oDAO.encode(admin.AdminPhonenumber, admin.AdminPhonenumber.Length);
                    admin.AdminPassword = pwd;
                    admin.AdminPhonenumber = mobNo;
                    if (oDAO.sentAdminToDB(admin))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("listAdmins", "AdminHome");
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
                return View();
            }
        
        public ActionResult listAdmins()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.adminList());
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblAdmin A = oDAO.getAdmin(id);
            if (A != null)
            {
                return View(A);
            }
            else
            {
                return RedirectToAction("listAdmins", "AdminHome");
            }
        }
        [HttpPost]
        public ActionResult EditAdmin(TblAdmin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    admin.ModifyDate = DateTime.Now;
                    string pwd = oDAO.encode(admin.AdminPassword, admin.AdminPassword.Length);
                    string mobNo = oDAO.encode(admin.AdminPhonenumber, admin.AdminPhonenumber.Length);
                    admin.AdminPassword = pwd;
                    admin.AdminPhonenumber = mobNo;
                    var oldimageName = admin.AdminImage;
                    foreach (string upload in Request.Files)
                    {
                        if (Request.Files[upload].ContentLength > 0)
                        {
                            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                            if (!Directory.Exists(RootFolder + "AdminImage/"))
                            {
                                Directory.CreateDirectory(RootFolder + "AdminImage/");

                            }
                            string path = RootFolder + "AdminImage/";
                            string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                            string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                            string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                            admin.AdminImage = newfilename;
                            Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                             var photoName = "";
                            photoName = oldimageName;
                            string fullPath = Server.MapPath("~/Uploads/AdminImage/" + photoName);
                    if (photoName != "profile-image.jpg")
                    {
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                        }
                    }

                    if (oDAO.sentAdminToDB(admin))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("listAdmins", "AdminHome");
                    }
                }

                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            return View(admin);
        }
        public ActionResult deleteAdmin(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblAdmin a = oDAO.getAdmin(id);
                var photoName = "";
                photoName = a.AdminImage;
                string fullPath = Server.MapPath("~/Uploads/AdminImage/" + photoName);
                if (oDAO.deleteAdmin(a))
                {
                    if (photoName != "profile-image.jpg")
                    {
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("listAdmins", "AdminHome");
        }

        #endregion
        #region Department
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(TblDepartment D)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddDepartment(D))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("AllDepartments", "AdminHome");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult AllDepartments()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListDepartments());
        }
        [HttpGet]
        public ActionResult EditDepartment(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblDepartment D = oDAO.getDepartment(id);
            if (D != null)
            {
                return View(D);
            }
            else
            {
                return RedirectToAction("AllDepartments", "AdminHome");
            }
        }
        [HttpPost]
        public ActionResult EditDepartment(TblDepartment D)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddDepartment(D))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("AllDepartments", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult deleteDepartment(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblDepartment D = oDAO.getDepartment(id);
                if (oDAO.deleteDepartment(D))
                {

                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch(Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("AllDepartments", "AdminHome");
            
        }
        #endregion
        #region Course
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(TblCourse course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddCourse(course))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("ListCourse", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult ListCourse()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListCourse());
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblCourse C = oDAO.getCourse(id);
            if (C != null)
            {
                return View(C);
            }
            else
            {
                return RedirectToAction("ListCourse", "AdminHome");
            }
        }
        [HttpPost]
        public ActionResult EditCourse(TblCourse C)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddCourse(C))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("ListCourse", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult DeleteCourse(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblCourse course = oDAO.getCourse(id);
                if (oDAO.DeleteCourse(course))
                {

                    TempData["Message"]= Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ListCourse", "AdminHome");
        }
        #endregion
        #region Subject
        [HttpGet]
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(TblSubject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddSubject(subject))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("ListSubjects", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult ListSubjects()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.getAllSubjects());
        }
        [HttpGet]
        public ActionResult EditSubject(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblSubject sub= oDAO.getSubject(id);
            if(sub!=null)
            {
                return View(sub);
            }
            else
            {
                return RedirectToAction("ListSubjects", "AdminHome");
            }
        }
        [HttpPost]
        public ActionResult EditSubject(TblSubject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddSubject(subject))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("ListSubjects", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult deleteSubject(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblSubject sub = oDAO.getSubject(id);
                if (oDAO.deleteSubject(sub))
                {

                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ListSubjects", "AdminHome");
        }
        #endregion
        #region Session
        [HttpGet]
        public ActionResult addSession()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addSession(TblSession session)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    session.SessionCreateddate = DateTime.Now;
                    if (oDAO.addSession(session))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("ListSession", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult ListSession()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.sessionList());
        }

        /*This fun return course list and it used to load course in course dropdown on change of
          dept from dropdown of dept in add session view and there we get jason in ajax call
         and load course list in dropdown.
        */
        public ActionResult getDepartmentCourse(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            IList<TblCourse> list= oDAO.getDepartmentCourse(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditSession(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblSession S = oDAO.getSession(id);
            if (S != null)
            {
                return View(S);
            }
            else
            {
                return RedirectToAction("ListSession", "AdminHome");
            }

        }
        [HttpPost]
        public ActionResult EditSession(TblSession S)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.addSession(S))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("ListSession", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult deleteSession(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblSession S = oDAO.getSession(id);
                if (oDAO.DeleteSession(S))
                {

                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ListSession", "AdminHome");
        }
        #endregion
        #region Book Upload
        [HttpGet]
        public ActionResult UploadBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadBook(TblBooks Book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (string upload in Request.Files)
                    {
                        if (Request.Files[upload].ContentLength > 0)
                        {
                            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                            if (!Directory.Exists(RootFolder + "BookFiles/"))
                            {
                                Directory.CreateDirectory(RootFolder + "BookFiles/");

                            }
                            string path = RootFolder + "BookFiles/";
                            string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                            string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                            string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                            Book.File= newfilename;
                            Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                        }
                    }
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    Book.BookDownloads = 0;
                    if (oDAO.uploadBook(Book))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("BookList", "AdminHome");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            return View();
           
        }
        public ActionResult BookList()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.booklist());
        }
        public FileResult DownloadBook(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblBooks book = oDAO.getBook(id);
            string file = book.File;

            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
            string FullPath = RootFolder + "BookFiles/" + file;
            book.BookDownloads = book.BookDownloads + 1;
            oDAO.uploadBook(book);
            return File(FullPath, MimeMapping.GetMimeMapping(file), Path.GetFileNameWithoutExtension(file)+ Path.GetExtension(file));
        }
        public ActionResult DeleteBook(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblBooks book = oDAO.getBook(id);
                var bookname = "";
                bookname = book.File;
                string fullPath = Server.MapPath("~/Uploads/BookFiles/" + bookname);
                if (oDAO.DeleteBook(book))
                {
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("BookList", "AdminHome");
        }
        #endregion
        
        #region Faculty
        [HttpGet]
        public ActionResult AddFaculty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFaculty(TblFaculty faculty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.createFaculty(faculty))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("facultyList", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        //public ActionResult facultyList()
        //{
        //    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
        //    return View(oDAO.ListDepartments());
        //}
        #endregion

        #region News
        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNews(TblNews news)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    news.PostedDate = DateTime.Now;
                    news.PostedBy = 1;
                    if (oDAO.addNews(news))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("NewsList", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult NewsList()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.newsList());
        }
        [HttpGet]
        public ActionResult DeleteNews(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblNews N = oDAO.getNews(id);
                if (oDAO.DeleteNews(N))
                {

                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("NewsList", "AdminHome");
        }
        #endregion

        #region Events
        [HttpGet]
        public ActionResult AddEvents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvents(TblEvents E)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (string upload in Request.Files)
                    {
                        if (Request.Files[upload].ContentLength > 0)
                        {
                            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                            if (!Directory.Exists(RootFolder + "EventImages/"))
                            {
                                Directory.CreateDirectory(RootFolder + "EventImages/");

                            }
                            string path = RootFolder + "EventImages/";
                            string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                            string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                            string newfilename = Filename + ext;
                            E.EventImage= newfilename;
                            Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                        }
                    }
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    E.PostedDate = DateTime.Now;
                    E.PostedBy = 1;
                    if (oDAO.addEvents(E))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("EventList", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult EventList()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.eventList());
        }
        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblEvents E = oDAO.getEvent(id);
                var photoName = "";
                photoName = E.EventImage;
                string fullPath = Server.MapPath("~/Uploads/EventImages/" + photoName);
                if (oDAO.DeleteEvent(E))
                {
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("EventList", "AdminHome");
        }
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblEvents E = oDAO.getEvent(id);
            if (E != null)
            {
                return View(E);
            }
            else
            {
                return RedirectToAction("EventList", "AdminHome");
            }

        }
        [HttpPost]
        public ActionResult EditEvent(TblEvents E)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    E.PostedDate = DateTime.Now;
                    if (oDAO.addEvents(E))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("EventList", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetailEvent(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblEvents E = oDAO.getEvent(id);
            if (E != null)
            {
                return View(E);
            }
            else
            {
                return RedirectToAction("EventList", "AdminHome");
            }

        }
        #endregion

        #region Student
        public string checkRollNumber(string RN)
        {
            if (RN != "")
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                string rollNumber = oDAO.checkStudentRollNumber(RN);
                if (rollNumber != null)
                {
                    return rollNumber;
                }
                else
                {
                    return rollNumber;
                }
            }
            else
            {
                string rollNumber = "Required";
                return rollNumber;
            }
        }
        [HttpGet]
        public ActionResult signUpStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signUpStudent(TblStudent student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (string upload in Request.Files)
                    {
                        if (Request.Files[upload].ContentLength > 0)
                        {
                            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                            if (!Directory.Exists(RootFolder + "StudentImages/"))
                            {
                                Directory.CreateDirectory(RootFolder + "StudentImages/");

                            }
                            string path = RootFolder + "StudentImages/";
                            string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                            string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                            string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                            student.StudentImage= newfilename;
                            Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                        }
                        else
                        {

                            student.StudentImage = "profile-image.jpg";
                        }
                    }
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    //teacher.TeacherDob = teacher.TeacherDob.Value.Date;
                    student.StudentAppstatus = Constants.allModelProperties.AppStatus;
                    student.StudentValid= Constants.allModelProperties.UnAprove;
                    student.StudentHasapp= Constants.allModelProperties.IsAppNon;
                    student.StudentApproveby = "Admin";
                    student.ModifyDate = DateTime.Now;
                    student.CreatedDate= DateTime.Now;
                    if (oDAO.signupStudent(student))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("teacherlist", "AdminHome");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            return View();

        }
        public ActionResult getCourseSession(int idc,int idd)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            IList<TblSession> list = oDAO.getDepartmentCourseSession(idc, idd);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getCourseSessionSection(int idc, int idd,int ids)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            string section = oDAO.getCourseSessionSection(idc, idd,ids);
            return Json(section, JsonRequestBehavior.AllowGet);
        }
        public ActionResult studentList()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListStudents());
        }
        [HttpGet]
        public ActionResult EditStudentByAdmin(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblStudent S = oDAO.getStudent(id);
            if (S != null)
            {
                return View(S);
            }
            else
            {
                return RedirectToAction("studentList", "AdminHome");
            }
        }
        [HttpPost]
        public ActionResult EditStudentByAdmin(TblStudent S)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    S.ModifyDate = DateTime.Now;
                    if (oDAO.signupStudent(S))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("studentList", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult deleteStudent(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblStudent S = oDAO.getStudent(id);
                var photoName = "";
                photoName = S.StudentImage;
                string fullPath = Server.MapPath("~/Uploads/StudentImages/" + photoName);
                if (oDAO.DeleteStudent(S))
                {
                    if (photoName != "profile-image.jpg")
                    {
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("studentList", "AdminHome");

        }

        #endregion

        #region Image Gallery
        [HttpGet]
        public ActionResult uploadEventImages()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uploadEventImages(UploadImage ui)
        {
            if (ModelState.IsValid)
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                int val=oDAO.AddEventName(ui.tblPhotofoldername);
                List<TblPhotogallery> list = new List<TblPhotogallery>();
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentLength > 0)
                    {
                        string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                        if (!Directory.Exists(RootFolder +"Events/"+ui.tblPhotofoldername.FolderName +"/"))
                        {
                            Directory.CreateDirectory(RootFolder + "Events/"+ui.tblPhotofoldername.FolderName + "/");

                        }
                        string path = RootFolder + "Events/" + ui.tblPhotofoldername.FolderName + "/";
                        string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                        string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                        string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                        ui.tblPhotogallery.Image= newfilename;
                        ui.tblPhotogallery.PhotofoldernameId = val;
                        list.Add(ui.tblPhotogallery);
                        Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                    }
                }
                foreach (var fn in list)
                {
                    oDAO.AddImagesInGallery(fn);
                }
            }

            return View(ui);
        }
        
        [HttpGet]
        public ActionResult uploadExistEventImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uploadExistEventImage(TblPhotogallery pg)
        {
            if (ModelState.IsValid)
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblPhotofoldername obj = oDAO.getFNd(pg.PhotofoldernameId.Value);
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentLength > 0)
                    {
                        string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                        if (!Directory.Exists(RootFolder + "Events/" +obj.FolderName + "/"))
                        {
                            Directory.CreateDirectory(RootFolder + "Events/" +obj.FolderName+ "/");

                        }
                        string path = RootFolder + "Events/" + obj.FolderName+ "/";
                        string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                        string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                        string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                        pg.Image= newfilename;
                        Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                        oDAO.AddImagesInGallery(pg);
                    }
                }
            }

            return View();
        }
        #endregion

        #region Adddaytime
        [HttpGet]
        public ActionResult AddTime()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTime(TblLecturetime L)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddTime(L))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("ListDayTime", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult ListDayTime()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListDayTime());
        }
        [HttpGet]
        public ActionResult deleteDayTime(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblLecturetime D = oDAO.getDayTime(id);
                if (oDAO.deleteDayTime(D))
                {

                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ListDayTime", "AdminHome");

        }
        #endregion

        #region AddTimeTable

        [HttpGet]
        public ActionResult AddTimetable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTimetable(TblTimetable T)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    TblTimetable tt= oDAO.getTimeTable(T.DepartmentId.Value, T.CourseId.Value, T.SessionId.Value, T.ClassSection);
                    if (tt == null)
                    {
                        Session["DeptID"] = T.DepartmentId;
                        int val = oDAO.AddTimeTable(T);
                        if (val != -1)
                        {
                            Session["TimeTableID"] = val;
                            TempData["Message"] = Constants.allModelProperties.registrationMessage;
                            return RedirectToAction("AddTimetableDetail", "AdminHome");
                        }
                    }
                    else {
                        ViewBag.Message = Constants.allModelProperties.ScheduleExist;
                        return View();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult SeeTimeTable()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListTimeTable());
        }
        public ActionResult SearchDeptCourseTimeTable(string idd,string idc)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            IList<TimeTableSessionView> list = oDAO.ListTimeTable(idd, idc);

            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach (TimeTableSessionView obj in list)
            {
                
                sb.Append("<tr><td class='text-center'>"+count.ToString()+"</td>");
                sb.Append("<td class='text-center'>"+obj.DepartmentName+"</td>");
                sb.Append("<td class='text-center'>"+obj.DepartmentCode+"</td>");
                sb.Append("<td class='text-center'>"+obj.CourseName+"</td>");
                sb.Append("<td class='text-center'>"+obj.CourseCode+"</td>");
                sb.Append("<td class='text-center'>"+obj.SessionStart+"-"+obj.SessionEnd+"</td>");
                sb.Append("<td class='text-center'>"+obj.ClassSection+"</td>");
                sb.Append("<td class='text-center'> @Html.ActionLink('See TimeTable', 'Edit', new {id="+obj.TimetableId+"}) |");
                sb.Append("@Html.ActionLink('Delete', 'deleteTimeTable', new {id="+obj.TimetableId+"})</td>");        
                sb.Append(count++);
                sb.Append("</tr>");
            }
            ViewBag.strng = sb;
            return Json(sb, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult deleteTimeTable(int id)
        {
            try
            {
                DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                TblTimetable D = oDAO.getTimeTable(id);
                IList<TblMorningtime> Ms = oDAO.ListMorningDelete(D.TimetableId);
                IList<TblEveningtime> Es = oDAO.ListEveningDelete(D.TimetableId);
                if (oDAO.deleteTimeTable(D))
                {
                    foreach(var item in Ms )
                    {
                        oDAO.deleteMorningSchedule(item);
                    }
                    foreach (var item in Es)
                    {
                        foreach (var item1 in Ms)
                        {
                            oDAO.deleteMorningSchedule(item1);
                        }
                    }
                    
                    TempData["Message"] = Constants.allModelProperties.DeleteMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constants.allModelProperties.MessageTypeError;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("SeeTimeTable", "AdminHome");

        }
#endregion
        #region Time Table Schedule
        [HttpGet]
        public ActionResult AddTimetableDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTimetableDetail(TimeTableModel ttm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                   int val= (Int32)Session["TimeTableID"];
                   ttm.TblMorningtime.TimetableId = val;
                   ttm.TblEveningtime.TimetableId = val;
                   ttm.TblEveningtime.SubjectId = ttm.TblMorningtime.SubjectId;
                   ttm.TblEveningtime.TeacherId = ttm.TblMorningtime.TeacherId;
                    
                    if (oDAO.AddTimeTableMorning(ttm.TblMorningtime))
                    {
                        oDAO.AddTimeTableEvening(ttm.TblEveningtime);
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("AddTimetableDetail", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditTimetableDetail(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblMorningtime M = oDAO.getMorningSchedule(id);
            TblEveningtime E = oDAO.getEveningSchedule(id);
            TimeTableModel tm = new TimeTableModel();
            tm.TblMorningtime = M;
            tm.TblEveningtime = E;
            if (tm != null)
            {
                return View(tm);
            }
            else
            {
                return RedirectToAction("SeeMorningEveningSchedule", "AdminHome");
            }
        }
        [HttpPost]
        public ActionResult EditTimetableDetail(TimeTableModel ttm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    ttm.TblEveningtime.SubjectId = ttm.TblMorningtime.SubjectId;
                    ttm.TblEveningtime.TeacherId = ttm.TblEveningtime.TeacherId;
                    if (oDAO.AddTimeTableMorning(ttm.TblMorningtime))
                    {
                        oDAO.AddTimeTableEvening(ttm.TblEveningtime);
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("AddTimetableDetail", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult SeeMorningEveningSchedule()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.TimeTableSchedule());
        }
        #endregion

        #region Morning Schedule
        [HttpGet]
        public ActionResult EditMorningSchedule(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblMorningtime tm= oDAO.getMorningSchedule(id);
            if (tm != null)
            {
                return View(tm);
            }
            else
            {
                return RedirectToAction("ShowMorningSchedule", "AdminHome");
            }
            
        }
        [HttpPost]
        public ActionResult EditMorningSchedule(TblMorningtime tm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    if (oDAO.AddTimeTableMorning(tm))
                    {
                        TempData["Message"] = Constants.allModelProperties.UpdateMessage;
                        return RedirectToAction("ListSession", "AdminHome");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult ShowMorningSchedule()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListMorningSchedule());
        }
        #endregion
        #region Evening Schedule

        public ActionResult ShowEveningSchedule()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.ListEveningSchedule());
        }
        #endregion
    }
}