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
        IStudentRepository Repository = new StudentRepository();
        public string WannaPlayDad()
        {
            return "NO!";
        }

        // GET: Students
        public ActionResult Index()
        {
            ViewBag.Lucas = "Hi dad";
            List<Student> students = Repository.GetAll();
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = Repository.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Repository.InsertOrUpdate(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index");
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
                Repository.InsertOrUpdate(student);

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }   
        }
    }
}