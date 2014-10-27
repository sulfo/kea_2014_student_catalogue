using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCatalog.Models;
using StudentCatalog.Repositories;

namespace StudentCatalog.Controllers
{
    public class CompetencyHeadersController : Controller
    {
        private CompetencyHeaderRepository _competencyHeaderRepository = 
            new CompetencyHeaderRepository();

        // GET: CompetencyHeaders
        public ActionResult Index()
        {
            return View(_competencyHeaderRepository.GetAll());
        }

        // GET: CompetencyHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeader competencyHeader = _competencyHeaderRepository.Find(id.Value);
            if (competencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeader);
        }

        // GET: CompetencyHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyHeaderId,Name")] CompetencyHeader competencyHeader)
        {
            if (ModelState.IsValid)
            {
                _competencyHeaderRepository.InsertOrUpdate(competencyHeader);
                _competencyHeaderRepository.Save();
                return RedirectToAction("Index");
            }

            return View(competencyHeader);
        }

        // GET: CompetencyHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeader competencyHeader = _competencyHeaderRepository.Find(id.Value);
            if (competencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeader);
        }

        // POST: CompetencyHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyHeaderId,Name")] CompetencyHeader competencyHeader)
        {
            if (ModelState.IsValid)
            {
                _competencyHeaderRepository.InsertOrUpdate(competencyHeader);
                _competencyHeaderRepository.Save();
                return RedirectToAction("Index");
            }
            return View(competencyHeader);
        }

        // GET: CompetencyHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeader competencyHeader = _competencyHeaderRepository.Find(id.Value);
            if (competencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeader);
        }

        // POST: CompetencyHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyHeader competencyHeader = _competencyHeaderRepository.Find(id);
            _competencyHeaderRepository.Delete(id);
            _competencyHeaderRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
