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
    public class ReviewsController : Controller
    {
        private ReviewContext db = new ReviewContext();
        private BlacklistContext dbBlacklist = new BlacklistContext();

        // GET: Reviews
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                GameContext dbGame = new GameContext();
                Game game = dbGame.Games.Find(id);
                ViewData["id"] = id;
                ViewData["name"] = game.GameName;
                ViewData["releasedate"] = game.GameReleaseDate;
            }
            else
            {
                ViewData["id"] = null;
            }
            return View(db.Reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create(int id)
        {
            ViewData["id"] = id;
            GameContext dbGame = new GameContext();
            Game game = dbGame.Games.Find(id);
            ViewData["id"] = id;
            ViewData["name"] = game.GameName;
            ViewData["releasedate"] = game.GameReleaseDate;
            ViewData["developerID"] = game.DeveloperID;
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,Title,Genre,Description,Score,DeveloperID,GameID")] Review review)
        {
            bool Banned = false;
            foreach (Blacklist blacklist in dbBlacklist.Blacklists.ToList())
            {
                if (blacklist.BlacklistIP == Request.UserHostAddress)
                {
                    Banned = true;
                }
            }

            if (ModelState.IsValid && Banned == false)
            {
                review.GameID = Convert.ToInt32(TempData["GameID"]);
                review.DeveloperID = Convert.ToInt32(TempData["DeveloperID"]);
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (Banned == true)
            {
                return RedirectToAction("../Blacklists/UserBlacklist/");
            }
            else
            {
                return View(review);
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,Title,Genre,Description,Score,DeveloperID,GameID")] Review review)
        {
            bool Banned = false;
            foreach (Blacklist blacklist in dbBlacklist.Blacklists.ToList())
            {
                if (blacklist.BlacklistIP == Request.UserHostAddress)
                {
                    Banned = true;
                }
            }

            if (ModelState.IsValid && Banned == false)
            {
                review.GameID = Convert.ToInt32(TempData["GameID"]);
                review.DeveloperID = Convert.ToInt32(TempData["DeveloperID"]);
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (Banned == true)
            {
                return RedirectToAction("../Blacklists/UserBlacklist/");
            }
            else
            {
                return View(review);
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool Banned = false;
            foreach (Blacklist blacklist in dbBlacklist.Blacklists.ToList())
            {
                if (blacklist.BlacklistIP == Request.UserHostAddress)
                {
                    Banned = true;
                }
            }
            if (Banned == false)
            {
                Review review = db.Reviews.Find(id);
                db.Reviews.Remove(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return RedirectToAction("../Blacklists/UserBlacklist/"); }
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
