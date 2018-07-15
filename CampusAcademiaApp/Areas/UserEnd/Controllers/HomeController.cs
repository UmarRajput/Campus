using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CampusAcademiaApp.Areas.UserEnd.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /UserEnd/Home/
        public ActionResult Index()
        {
            return View();
        }

        #region Notes
        /*This fun return subject list and it used to load subject in subject dropdown on change of
          dept from dropdown of dept in upload notes view and there we get jason on ajax call
         and load subject list in dropdown.
        */
        public ActionResult getDepartmentSubjects(int id)
        { 
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            IList<TblSubject> list= oDAO.getDepartmentSubjects(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UploadNotes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadNotes(TblNotes notes)
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
                            if (!Directory.Exists(RootFolder + "NotesFiles/"))
                            {
                                Directory.CreateDirectory(RootFolder + "NotesFiles/");

                            }
                            string path = RootFolder + "NotesFiles/";
                            string Filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files[upload].FileName);
                            string ext = System.IO.Path.GetExtension(Request.Files[upload].FileName);
                            string newfilename = Filename + DateTime.Now.ToString("ddMMyyyyttmm") + ext;
                            notes.NotesFile = newfilename;
                            Request.Files[upload].SaveAs(System.IO.Path.Combine(path, newfilename));
                        }
                    }
                    DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
                    notes.SessionId = 1;
                    notes.NotesPosteddate = DateTime.Now;
                    notes.CourseId = 1;
                    notes.UserId = 1;
                    notes.UserType = "Student";
                    notes.UpdatedNotes = "NO";
                    notes.NotesDownloads = 0;
                    if (oDAO.uploadNotes(notes))
                    {
                        TempData["Message"] = Constants.allModelProperties.registrationMessage;
                        return RedirectToAction("NotesList", "Home");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            return View();

        }
        public ActionResult NotesList()
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            return View(oDAO.noteslist());
        }
        
        public FileResult DownloadNotes(int id)
        {
            DAO oDAO = new DAO(MvcApplication.SF.GetCurrentSession());
            TblNotes note = oDAO.getNotes(id);
            string file = note.NotesFile;

            string RootFolder = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
            string FullPath = RootFolder + "NotesFiles/" + file;
            note.NotesDownloads=note.NotesDownloads+ 1;
            oDAO.uploadNotes(note);
            return File(FullPath, MimeMapping.GetMimeMapping(file), Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file));
        }

        [HttpGet]
        public ActionResult addteaacher()
        {
            return View();
        }
        #endregion

        
    }
}