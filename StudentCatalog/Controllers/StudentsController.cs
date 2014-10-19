﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using StudentCatalog.Models;

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