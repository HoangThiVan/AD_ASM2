using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM2_CodeFirst.Models;

namespace ASM2_CodeFirst.Controllers
{
    public class UserClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserClass
        public ActionResult Index()
        {
            var userClasses = db.UserClasses.Include(u => u.Class);
            return View(userClasses.ToList());
        }

        // GET: UserClass/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClass userClass = db.UserClasses.Find(id);
            if (userClass == null)
            {
                return HttpNotFound();
            }
            return View(userClass);
        }

        // GET: UserClass/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name");
            ViewBag.Users = db.Users;
            return View();
        }

        // POST: UserClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int ClassID, string[] userIds)
        {
            foreach (string userId in userIds)
            {
                UserClass userClass = new UserClass();
                userClass.ClassID = ClassID;
                userClass.UserID = userId;
                db.UserClasses.Add(userClass);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "UserClass");
        }

        // GET: UserClass/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClass userClass = db.UserClasses.Find(id);
            if (userClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", userClass.ClassID);
            return View(userClass);
        }

        // POST: UserClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,ClassID")] UserClass userClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", userClass.ClassID);
            return View(userClass);
        }

        // GET: UserClass/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClass userClass = db.UserClasses.Find(id);
            if (userClass == null)
            {
                return HttpNotFound();
            }
            return View(userClass);
        }

        // POST: UserClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserClass userClass = db.UserClasses.Find(id);
            db.UserClasses.Remove(userClass);
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
