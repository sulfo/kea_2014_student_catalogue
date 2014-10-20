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
        IStudentRepository repository = new StudentRepository();
        public string WannaPlayDad()
        {
            return "NO!";
        }

        // GET: Students
        public ActionResult Index()
        {
            ViewBag.Lucas = "Hi dad";
            List<Student> students = repository.GetAll();
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = repository.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                repository.InsertOrUpdate(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student student = repository.Find(id);
            repository.Delete(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //save
                repository.InsertOrUpdate(student);

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }   
        }
    }
}