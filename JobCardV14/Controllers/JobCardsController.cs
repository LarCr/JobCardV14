using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobCardV14.Models;

namespace JobCardV14.Controllers
{
    public class JobCardsController : Controller
    {
        private JobCardDatabaseEntities db = new JobCardDatabaseEntities();

        // GET: JobCards
        public ActionResult Index()
        {
            var jobCards = db.JobCards.Include(j => j.Customer).Include(j => j.Engineer);
            return View(jobCards.ToList());
        }

        // GET: JobCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCard jobCard = db.JobCards.Find(id);
            if (jobCard == null)
            {
                return HttpNotFound();
            }
            return View(jobCard);
        }

        // GET: JobCards/Create
        public ActionResult Create()
        {
            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustomerName");
            ViewBag.EngId = new SelectList(db.Engineers, "EngId", "EngineerName");
            return View();
        }

        // POST: JobCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobId,CustId,EngId,JobDetails,SiteContact,PartsUsed,Date,TimeOnSite")] JobCard jobCard)
        {
            if (ModelState.IsValid)
            {
                db.JobCards.Add(jobCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustomerName", jobCard.CustId);
            ViewBag.EngId = new SelectList(db.Engineers, "EngId", "EngineerName", jobCard.EngId);
            return View(jobCard);
        }

        // GET: JobCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCard jobCard = db.JobCards.Find(id);
            if (jobCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustomerName", jobCard.CustId);
            ViewBag.EngId = new SelectList(db.Engineers, "EngId", "EngineerName", jobCard.EngId);
            return View(jobCard);
        }

        // POST: JobCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobId,CustId,EngId,JobDetails,SiteContact,PartsUsed,Date,TimeOnSite")] JobCard jobCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustId = new SelectList(db.Customers, "CustId", "CustomerName", jobCard.CustId);
            ViewBag.EngId = new SelectList(db.Engineers, "EngId", "EngineerName", jobCard.EngId);
            return View(jobCard);
        }

        // GET: JobCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCard jobCard = db.JobCards.Find(id);
            if (jobCard == null)
            {
                return HttpNotFound();
            }
            return View(jobCard);
        }

        // POST: JobCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobCard jobCard = db.JobCards.Find(id);
            db.JobCards.Remove(jobCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
