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
    public class UserTopicController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTopic
        public ActionResult Index()
        {
            var userTopics = db.UserTopics.Include(u => u.Topic);
            return View(userTopics.ToList());
        }

        // GET: UserTopic/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTopic userTopic = db.UserTopics.Find(id);
            if (userTopic == null)
            {
                return HttpNotFound();
            }
            return View(userTopic);
        }

        // GET: UserTopic/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Topics, "ID", "Name");
            ViewBag.Users = db.Users;
            return View();
        }

        // POST: UserTopic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int ID, string[] userIds)
        {
            foreach (string userId in userIds)
            {
                UserTopic userTopic = new UserTopic();
                userTopic.ID =ID;
                userTopic.UserID = userId;
                db.UserTopics.Add(userTopic);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "UserTopic");
        }

        // GET: UserTopic/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTopic userTopic = db.UserTopics.Find(id);
            if (userTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Topics, "ID", "Name", userTopic.ID);
            return View(userTopic);
        }

        // POST: UserTopic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,ID")] UserTopic userTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Topics, "ID", "Name", userTopic.ID);
            return View(userTopic);
        }

        // GET: UserTopic/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTopic userTopic = db.UserTopics.Find(id);
            if (userTopic == null)
            {
                return HttpNotFound();
            }
            return View(userTopic);
        }

        // POST: UserTopic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserTopic userTopic = db.UserTopics.Find(id);
            db.UserTopics.Remove(userTopic);
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
