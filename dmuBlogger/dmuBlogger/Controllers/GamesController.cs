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
    public class GamesController : Controller
    {
        private GameContext db = new GameContext();
        private BlacklistContext dbBlacklist = new BlacklistContext();


        // GET: Games
        public ActionResult Index(int? id, string sortOrder, string searchStringName, string searchStringGenre)
        {

            if (id != null)
            {
                DeveloperContext dbDeveloper = new DeveloperContext();
                Developer developer = dbDeveloper.Developers.Find(id);
                ViewData["id"] = id;
                ViewData["name"] = developer.Name;
                ViewData["description"] = developer.Description;
            }
            else
            {
                ViewData["id"] = null;
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "GameReleaseDate" ? "date_desc" : "Date";
            var games = from s in db.Games select s;

            if (!String.IsNullOrEmpty(searchStringName))
            {
                games = games.Where(s => s.GameName.Contains(searchStringName));
            }
            if (!String.IsNullOrEmpty(searchStringGenre))
            {
                games = games.Where(s => s.GameGenre.Contains(searchStringGenre));
            }

            switch (sortOrder)
            {
                case "GameId":
                    games = games.OrderByDescending(s => s.GameId);
                    break;
                case "Name":
                    games = games.OrderBy(s => s.GameName);
                    break;
                case "GameReleaseDate":
                    games = games.OrderByDescending(s => s.GameReleaseDate);
                    break;
                default:
                    games = games.OrderBy(s => s.GameName);
                    break;
            }
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,DeveloperID,GameName,GameGenre,GameReleaseDate")] Game game)
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
                var x = game.GameGenre;
                game.DeveloperID = Convert.ToInt32(TempData["id"]);
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (Banned == true)
            {
                return RedirectToAction("../Blacklists/UserBlacklist/");
            }
            else
            {
                return View(game);
            }
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,DeveloperID,GameName,GameGenre,GameReleaseDate")] Game game)
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
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (Banned == true)
            {
                return RedirectToAction("../Blacklists/UserBlacklist/");
            }
            else
            {
                return View(game);
            }
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
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
                Game game = db.Games.Find(id);
                db.Games.Remove(game);
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
