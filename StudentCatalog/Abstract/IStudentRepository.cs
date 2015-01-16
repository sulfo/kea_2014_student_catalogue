using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCatalog.Models;

namespace StudentCatalog.Abstract
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Find(int id);
        void Delete(int id);
        void InsertOrUpdate(Student student);
        void Save();
    }
}
