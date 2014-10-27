using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using StudentCatalog.Models;

namespace StudentCatalog.Abstract
{
    public interface ICompetencyHeaderRepository
    {
        IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties);
        List<CompetencyHeader> GetAll();
        CompetencyHeader Find(int id);
        void Delete(int id);
        void InsertOrUpdate(CompetencyHeader competencyHeader);
        void Save();
    }
}
