using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StudentCatalog.Abstract;
using StudentCatalog.Models;

namespace StudentCatalog.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public Student Find(int id)
        {
            return _db.Students.Find(id);
        }

        public void Delete(Student student)
        {
            _db.Entry(student).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == 0)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}