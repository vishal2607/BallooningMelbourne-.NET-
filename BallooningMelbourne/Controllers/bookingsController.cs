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
    public class bookingsController : Controller
    {
        private BookingModel db = new BookingModel();

        // GET: bookings
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var bookings = db.bookings.Where(s => s.UserId == userId).ToList();
            return View(bookings);
        }

      


        // GET: bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: bookings/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName");
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize]
        public ActionResult Create([Bind(Include = "BOOKINGID,PASSENGERCOUNT,PhoneNo,EventId,Rating")] booking booking)
        {
            booking.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(booking);
            if (ModelState.IsValid)
            {
                db.bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName", booking.EventId);
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", booking.UserId);
            return View(booking);
        }


        //public ActionResult Create([Bind(Include = "BOOKINGID,PASSENGERCOUNT,PhoneNo,UserId,EventId,Rating")] booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.bookings.Add(booking);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName", booking.EventId);
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", booking.UserId);
        //    return View(booking);
        //}

        // GET: bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName", booking.EventId);
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", booking.UserId);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOKINGID,PASSENGERCOUNT,PhoneNo,UserId,EventId,Rating")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName", booking.EventId);
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", booking.UserId);
            return View(booking);
        }

        public ActionResult Rating(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName", booking.EventId);
         //   ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", booking.UserId);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rating(int id, int rating)
        {
            booking booking = db.bookings.Find(id);
            booking.Rating = rating;
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.EventId = new SelectList(db.AdminEventtables, "EventId", "EventName", booking.EventId);
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", booking.UserId);
            return View(booking);
        }

        // GET: bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
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
