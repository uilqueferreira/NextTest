using ForumTest2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForumTest2.Controllers
{
    public class TopicController222 : Controller
    {
        private ManagerContext db = new ManagerContext();

        // GET: Acesso
        public ActionResult Index()
        {
            return View(db.ApplicationUsers.ToList());
        }

        // GET: Acesso/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.ApplicationUsers.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Acesso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acesso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Pass,Active,Profile,FirstName,LastName")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUsers.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Acesso/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.ApplicationUsers.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Acesso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Pass,Active,Profile,FirstName,LastName")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Acesso/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.ApplicationUsers.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Acesso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            ApplicationUser user = db.ApplicationUsers.Find(Id);
            db.ApplicationUsers.Remove(user);
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
