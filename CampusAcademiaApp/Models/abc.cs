using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusAcademiaApp {

    public  class abc
    {
        public virtual int DepartmentId { get; set; }
        public virtual string CourseName { get; set; }
        public virtual string DepartmentName { get; set; }
        public virtual string CourseCode { get; set; }






        //#region Extensibility Method Definitions

        //partial void OnCreated();

        //public coursecoursedepartment()
        //{
        //    OnCreated();
        //}



        //public override bool Equals(object obj)
        //{
        //    coursecoursedepartment toCompare = obj as coursecoursedepartment;
        //    if (toCompare == null)
        //    {
        //        return false;
        //    }

        //    if (!Object.Equals(this.DepartmentId, toCompare.DepartmentId))
        //        return false;
        //    //if (!Object.Equals(this.CoursesId, toCompare.CoursesId))
        //    //    return false;
        //    //if (this.RatingId != null && toCompare.RatingId != null)
        //    //{
        //    //    if (!Object.Equals(this.RatingId, toCompare.RatingId))
        //    //        return false;
        //    //}

        //    return true;
        //}

        //public override int GetHashCode()
        //{
        //    int hashCode = 13;
        //    hashCode = (hashCode * 7) + DepartmentId.GetHashCode();
        //    //hashCode = (hashCode * 7) + CoursesId.GetHashCode();
        //    //hashCode = (hashCode * 7) + RatingId.GetHashCode();
        //    return hashCode;
        //}

        //#endregion
    }


 
}
