﻿using System;
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
    public class BlacklistsController : Controller
    {
        private BlacklistContext db = new BlacklistContext();

        // GET: Blacklists
        public ActionResult Index()
        {
            return View(db.Blacklists.ToList());
        }

        // GET: Blacklists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blacklist blacklist = db.Blacklists.Find(id);
            if (blacklist == null)
            {
                return HttpNotFound();
            }
            return View(blacklist);
        }

        // GET: Blacklists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blacklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlacklistId,BlacklistIP,BlacklistReason")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                db.Blacklists.Add(blacklist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blacklist);
        }

        // GET: Blacklists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blacklist blacklist = db.Blacklists.Find(id);
            if (blacklist == null)
            {
                return HttpNotFound();
            }
            return View(blacklist);
        }

        // POST: Blacklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlacklistId,BlacklistIP,BlacklistReason")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blacklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blacklist);
        }

        // GET: Blacklists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blacklist blacklist = db.Blacklists.Find(id);
            if (blacklist == null)
            {
                return HttpNotFound();
            }
            return View(blacklist);
        }

        // POST: Blacklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blacklist blacklist = db.Blacklists.Find(id);
            db.Blacklists.Remove(blacklist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: User ban message
        public ActionResult UserBlacklist()
        {
            ViewBag.IP = Request.UserHostAddress;
            foreach (Blacklist blacklist in db.Blacklists.ToList())
            {
                string IP = blacklist.BlacklistIP;
            }
            return View(db.Blacklists.ToList());
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
