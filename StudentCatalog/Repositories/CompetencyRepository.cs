using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Web;
using StudentCatalog.Abstract;
using StudentCatalog.Models;

namespace StudentCatalog.Repositories
{
    public class CompetencyRepository : ICompetencyRepository
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public List<Competency> GetAll()
        {
            return _db.Competencies.ToList();
        }
 

        public Competency Find(int id)
        {
            return _db.Competencies.Find(id);
        }

        public void Delete(int id)
        {
            _db.Competencies.Remove(Find(id));
        }

        public void InsertOrUpdate(Competency competency)
        {
            if (competency.CompetencyId == default(int))
            {
                _db.Competencies.Add(competency);
            }
            else
            {
                _db.Entry(competency).State = EntityState.Modified;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties)
        {
            IQueryable<Competency> query = _db.Competencies;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}