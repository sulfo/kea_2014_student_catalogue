using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCatalog.Abstract;
using StudentCatalog.Models;

namespace StudentCatalog.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext _db =
            new ApplicationDbContext();

        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public Student Find(int id)
        {
            return _db.Students.Find(id);
        }

        public void Delete(int id)
        {
            _db.Students.Remove(_db.Students.Find(id));
        }

        public void InsertOrUpdate(Student student)
        {
            //figure out if student is a new
            //or edited object.
            //if (student.StudentId == 0)

            if (student.StudentId == default(int))
            {
                _db.Students.Add(student);
            }
            else
            {
                _db.Entry(student).State = EntityState.Modified;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}