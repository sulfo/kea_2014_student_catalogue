using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCatalog.Abstract;
using StudentCatalog.Models;
using StudentCatalog.Repositories;

namespace StudentCatalog.Controllers
{
    public class CompetenciesController : Controller
    {
        private readonly ICompetencyHeaderRepository _competencyHeaderRepository;
        private readonly ICompetencyRepository _competencyRepository;

        public CompetenciesController(
            ICompetencyHeaderRepository competencyHeaderRepository
            , ICompetencyRepository competencyRepository)
        {
            _competencyHeaderRepository = competencyHeaderRepository;
            _competencyRepository = competencyRepository;
        }


        // GET: Competencies
        public ActionResult Index()
        {
            var competencies = _competencyRepository.AllIncluding(c => c.CompetencyHeader);
            return View(competencies.ToList());
        }

        // GET: Competencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = _competencyRepository.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // GET: Competencies/Create
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderId = 
                new SelectList(_competencyHeaderRepository.GetAll(), 
                    "CompetencyHeaderId", "Name");

            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                _competencyRepository.InsertOrUpdate(competency);
                _competencyRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CompetencyHeaderId = new SelectList(_competencyHeaderRepository.GetAll(), "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // GET: Competencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = _competencyRepository.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetencyHeaderId = new SelectList(_competencyHeaderRepository.GetAll(), "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                _competencyRepository.InsertOrUpdate(competency);
                _competencyHeaderRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CompetencyHeaderId = new SelectList(_competencyHeaderRepository.GetAll(), "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // GET: Competencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = _competencyRepository.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            _competencyRepository.Delete(id);
            _competencyRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
