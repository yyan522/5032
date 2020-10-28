using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EASYGO._2.Models;
using Microsoft.AspNet.Identity;

namespace EASYGO._2.Controllers
{
    public class BookingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Bookings
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            //var bookings = db.Bookings.Include(b => b.Car);
            var bookings = db.Bookings.Where(r => r.Customer_Id == userId);
            return View(bookings.ToList());
        }
        

        public ActionResult BookCar()
        {
            return View(db.Cars.ToList());
        }

        // Get Book car id 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookCar([Bind(Include = "Car_Id,Registration_number,Car_Make,Register_Time,Car_description")] Car car)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(car).State = EntityState.Modified;
                //db.SaveChanges();
                var ChoosenCar_id = car.Car_Id;
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        //public ActionResult Create()
        //{
           
        //    ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Registration_number");
        //    return View();
        //}
        public ActionResult Create(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;
            ViewBag.Car_Id = id;
            return View();
        }
        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Car_Id,Start_time,End_time,Customer_Id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Registration_number", booking.Car_Id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Registration_number", booking.Car_Id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Car_Id,Start_time,End_time,Customer_Id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Car_Id = new SelectList(db.Cars, "Car_Id", "Registration_number", booking.Car_Id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
