using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentCatalog.Models;

namespace StudentCatalog.Abstract
{
    public interface ICompetencyRepository
    {
        IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties);

        List<Competency> GetAll();
        Competency Find(int id);
        void Delete(int id);
        void InsertOrUpdate(Competency competency);
        void Save();
    }
}
