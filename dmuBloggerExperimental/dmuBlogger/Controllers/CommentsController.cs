using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dmuBlogger.Data;
using dmuBlogger.Models;

namespace dmuBlogger.Controllers
{
    public class CommentsController : Controller
    {
        private CommentContext db = new CommentContext();

        // GET: Comments
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                ReviewContext dbReview = new ReviewContext();
                Review review = dbReview.Reviews.Find(id);
                ViewData["id"] = id;
                ViewData["name"] = review.Title;
                return View(db.Comments.ToList());
            }
            else
            {
                ViewData["id"] = null;
                return RedirectToAction("../Home/Index");
            }
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,ReviewID,Description,Name,EMail")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.ReviewID = Convert.ToInt32(TempData["ReviewID"]);
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("../Comments/Index/" + Convert.ToString(TempData["ReviewID"]));
                //return RedirectToAction("Index");
            }
            //ReviewContext dbReview = new ReviewContext();
            //Review review = dbReview.Reviews.Find(Convert.ToInt32(TempData["ReviewID"]));
            //ViewData["id"] = Convert.ToInt32(TempData["ReviewID"]);
            //ViewData["name"] = review.Title;
            //return View(db.Comments.ToList());
            return RedirectToAction("~/Comments/Index/"+Convert.ToString(TempData["ReviewID"]));
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,ReviewID,Description,Name,EMail")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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