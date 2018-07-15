using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CampusAcademiaApp
{
    public class Library
    {
        public virtual int BookId { get; set; }
        [Display(Name = "Book Title")]
        public virtual string BookTitle { get; set; }
        [Display(Name = "Book Author")]
        public virtual string BookAuthor { get; set; }
        [Display(Name = "File")]
        public virtual string File { get; set; }
        [Display(Name = "Book Downloads")]
        public virtual int? BookDownloads { get; set; }
        [Display(Name = "Department Name")]
        public virtual string DepartmentName { get; set; }

    }
}