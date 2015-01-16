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
using StudentCatalog.ViewModels;

namespace StudentCatalog.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentRepository _studentRepository;
        private readonly ICompetencyHeaderRepository _competencyHeaderRepository;

        public StudentsController(IStudentRepository studentRepository, ICompetencyHeaderRepository competencyHeaderRepository)
        {
            _studentRepository = studentRepository;
            _competencyHeaderRepository = competencyHeaderRepository;
        }


        public string WannaPlayDad()
        {
            return "NO!";
        }

        // GET: Students
        public ActionResult Index()
        {
            ViewBag.Lucas = "Hi dad";
            List<Student> students = _studentRepository.GetAll().ToList();
            List<CompetencyHeader> competencyHeaders =
                _competencyHeaderRepository.AllIncluding(x => x.Competencies).ToList();

            StudentIndexViewModel vm = new StudentIndexViewModel
            {
                CompetencyHeaders = competencyHeaders,
                Students = students
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = _studentRepository.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string path = Server == null ? "" : Server.MapPath("~");
                student.SaveImage(image, path , "/UserUploads/ProfileImages/");
                _studentRepository.InsertOrUpdate(student);
                _studentRepository.Save();
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
        public ActionResult Create(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                //save
                string path = Server == null ? "" : Server.MapPath("~");
                student.SaveImage(image, path, "/UserUploads/ProfileImages/");
                _studentRepository.InsertOrUpdate(student);
                _studentRepository.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }   
        }
    }
}