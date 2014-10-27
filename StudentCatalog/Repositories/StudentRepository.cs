using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Student student)
        {
            //figure out if student is a new
            //or edited object.
            //if (student.StudentId == 0)

            if (student.StudentId == default(int))
            {

            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}