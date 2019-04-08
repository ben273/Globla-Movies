using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Globla_Movies.Models;

namespace Globla_Movies.Controllers
{
    public class MoviesController : Controller
    {
        private GMEntities db = new GMEntities();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Movie_Dir).Include(m => m.Movie_Genre).Include(m => m.rating);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.mov_id = new SelectList(db.Movie_Dir, "mov_id", "mov_id");
            ViewBag.mov_id = new SelectList(db.Movie_Genre, "mov_id", "mov_id");
            ViewBag.mov_id = new SelectList(db.ratings, "mov_id", "mov_id");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mov_id,mov_title,mov_year,mov_time_,mov_lang,mov_dt_rel,mov_rel_country_,mov_Art")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mov_id = new SelectList(db.Movie_Dir, "mov_id", "mov_id", movie.mov_id);
            ViewBag.mov_id = new SelectList(db.Movie_Genre, "mov_id", "mov_id", movie.mov_id);
            ViewBag.mov_id = new SelectList(db.ratings, "mov_id", "mov_id", movie.mov_id);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.mov_id = new SelectList(db.Movie_Dir, "mov_id", "mov_id", movie.mov_id);
            ViewBag.mov_id = new SelectList(db.Movie_Genre, "mov_id", "mov_id", movie.mov_id);
            ViewBag.mov_id = new SelectList(db.ratings, "mov_id", "mov_id", movie.mov_id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mov_id,mov_title,mov_year,mov_time_,mov_lang,mov_dt_rel,mov_rel_country_,mov_Art")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mov_id = new SelectList(db.Movie_Dir, "mov_id", "mov_id", movie.mov_id);
            ViewBag.mov_id = new SelectList(db.Movie_Genre, "mov_id", "mov_id", movie.mov_id);
            ViewBag.mov_id = new SelectList(db.ratings, "mov_id", "mov_id", movie.mov_id);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
