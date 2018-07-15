using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusAcademiaApp
{
    public class DeptSubjectView
    {
        public virtual int SubjectId { get; set; }
       
        public virtual string SubjectTitle { get; set; }
        
        public virtual string SubjectCode { get; set; }
        
        public virtual int SubjectCredithour { get; set; }

       // public virtual int DepartmentId { get; set; }
     
        public virtual string DepartmentName { get; set; }

    }
}