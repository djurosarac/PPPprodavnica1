using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPPprodavnica1;

namespace PPPprodavnica1.Controllers
{
    public class RacunsController : Controller
    {
        private ProjekatEntities db = new ProjekatEntities();

        // GET: Racuns
        public ActionResult Index()
        {
            var racun = db.Racun.Include(r => r.Proizvod);
            return View(racun.ToList());
        }

        // GET: Racuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racuns/Create
        public ActionResult Create()
        {
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv");
            return View();
        }

        // POST: Racuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRacuna,BarKodArtikla,Kolicina,UkupnaVrednost,Datum,Vreme")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Racun.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", racun.BarKodArtikla);
            return View(racun);
        }

        // GET: Racuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", racun.BarKodArtikla);
            return View(racun);
        }

        // POST: Racuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRacuna,BarKodArtikla,Kolicina,UkupnaVrednost,Datum,Vreme")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", racun.BarKodArtikla);
            return View(racun);
        }

        // GET: Racuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racun.Find(id);
            db.Racun.Remove(racun);
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
