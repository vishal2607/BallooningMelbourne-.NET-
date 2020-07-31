using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BallooningMelbourne.Models;
using Microsoft.AspNet.Identity;

namespace BallooningMelbourne.Controllers
{
    public class AdminEventtablesController : Controller
    {
        private AdminEventModel db = new AdminEventModel();

        // GET: AdminEventtables
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var adminEventtables = db.AdminEventtables.Where(s => s.UserId == userId).ToList();
            return View(adminEventtables);
        }


        // GET: AdminEventtables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminEventtable adminEventtable = db.AdminEventtables.Find(id);
            if (adminEventtable == null)
            {
                return HttpNotFound();
            }
            return View(adminEventtable);
        }

        // GET: AdminEventtables/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AdminEventtables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "EventId,EventName,EventAddress,EventCapacity,Doj,Price,Source,Destination,Duration,Description")] AdminEventtable adminEventtable)
        {
            adminEventtable.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(adminEventtable);
            if (ModelState.IsValid)
            {
                db.AdminEventtables.Add(adminEventtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Userid = new SelectList(db.AspNetUsers, "Id", "Email", adminEventtable.UserId);
            return View(adminEventtable);
        }


        // GET: AdminEventtables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminEventtable adminEventtable = db.AdminEventtables.Find(id);
            if (adminEventtable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", adminEventtable.UserId);
            return View(adminEventtable);
        }

        // POST: AdminEventtables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,EventAddress,UserId,EventCapacity,Doj,Price,Source,Destination,Duration,Description")] AdminEventtable adminEventtable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminEventtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", adminEventtable.UserId);
            return View(adminEventtable);
        }

        // GET: AdminEventtables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminEventtable adminEventtable = db.AdminEventtables.Find(id);
            if (adminEventtable == null)
            {
                return HttpNotFound();
            }
            return View(adminEventtable);
        }

        // POST: AdminEventtables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminEventtable adminEventtable = db.AdminEventtables.Find(id);
            db.AdminEventtables.Remove(adminEventtable);
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
