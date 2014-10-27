using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCatalog.Models
{
    public class CompetencyHeader
    {
        public int CompetencyHeaderId { get; set; }
        public String Name { get; set; }

        //navigation property
        public virtual ICollection<Competency> Competencies { get; set; }

    }
}