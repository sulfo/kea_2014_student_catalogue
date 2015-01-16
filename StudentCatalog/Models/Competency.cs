using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalog.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public String Name { get; set; }

        public virtual int CompetencyHeaderId { get; set; }
        public virtual CompetencyHeader CompetencyHeader { get; set; }


    }
}