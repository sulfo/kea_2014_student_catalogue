using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCatalog.Models
{
    public class Student
    {
        //C#: Properties start with capital letter

        //Java way of doing things..
        //private int studentId;

        //public void setStudentId(int studentId)
        //{
        //    this.studentId = studentId;
        //}

        //public int getStudentId()
        //{
        //    return studentId;
        //}

        public int StudentId {get ; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public String Firstname { get; set; }
        
        [Required(ErrorMessage = "Lastname is required")]
        public String Lastname { get; set; }
        
        [Required(ErrorMessage = "Stupid you!")]
        [EmailAddress]
        public String Email { get; set; }

        public String MobilePhone { get; set; }

    }
}