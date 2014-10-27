using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using StudentCatalog.Abstract;
using StudentCatalog.Models;
using StudentCatalog.Repositories;

namespace StudentCatalog.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public string WannaPlayDad()
        {
            return "NO!";
        }

        // GET: Students
        public ActionResult Index()
        {
            ViewBag.Lucas = "Hi dad";
            List<Student> students = _db.Students.ToList();
            
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = _db.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                student.SaveImage(image, Server.MapPath("~"), "/UserUploads/ProfileImages/");
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //save
                _db.Students.Add(student);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }   
        }
    }
}