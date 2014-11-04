using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCatalog.Models;

namespace StudentCatalog.ViewModels
{
    public class StudentIndexViewModel
    {
        public List<Student> Students { get; set; }
        public List<CompetencyHeader> CompetencyHeaders { get; set; }
    }
}