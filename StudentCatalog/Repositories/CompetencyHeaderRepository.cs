using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentCatalog.Abstract;
using StudentCatalog.Models;

namespace StudentCatalog.Repositories
{
    public class CompetencyHeaderRepository : ICompetencyHeaderRepository
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public List<CompetencyHeader> GetAll()
        {
            return _db.CompetencyHeaders.ToList();
        }

        public IEnumerable<CompetencyHeader> All
        {
            get { return _db.CompetencyHeaders; }
        }

        public CompetencyHeader Find(int id)
        {
            return _db.CompetencyHeaders.Find(id);
        }

        public void Delete(int id)
        {
            _db.CompetencyHeaders.Remove(Find(id));
        }

        public void InsertOrUpdate(CompetencyHeader competencyHeader)
        {
            if (competencyHeader.CompetencyHeaderId == default(int))
            {
                _db.CompetencyHeaders.Add(competencyHeader);
            }
            else
            {
                _db.Entry(competencyHeader).State = EntityState.Modified;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }



        public IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = _db.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}