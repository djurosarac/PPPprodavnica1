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
    public class ProdavnicasController : Controller
    {
        private ProjekatEntities db = new ProjekatEntities();

        // GET: Prodavnicas
        public ActionResult Index()
        {
            var prodavnica = db.Prodavnica.Include(p => p.Proizvod);
            return View(prodavnica.ToList());
        }

        // GET: Prodavnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodavnica prodavnica = db.Prodavnica.Find(id);
            if (prodavnica == null)
            {
                return HttpNotFound();
            }
            return View(prodavnica);
        }

        // GET: Prodavnicas/Create
        public ActionResult Create()
        {
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv");
            return View();
        }

        // POST: Prodavnicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RbUnosa,BarKodArtikla,Kolicina,datum,Vreme")] Prodavnica prodavnica)
        {
            if (ModelState.IsValid)
            {
                db.Prodavnica.Add(prodavnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", prodavnica.BarKodArtikla);
            return View(prodavnica);
        }

        // GET: Prodavnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodavnica prodavnica = db.Prodavnica.Find(id);
            if (prodavnica == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", prodavnica.BarKodArtikla);
            return View(prodavnica);
        }

        // POST: Prodavnicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RbUnosa,BarKodArtikla,Kolicina,datum,Vreme")] Prodavnica prodavnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodavnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", prodavnica.BarKodArtikla);
            return View(prodavnica);
        }

        // GET: Prodavnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodavnica prodavnica = db.Prodavnica.Find(id);
            if (prodavnica == null)
            {
                return HttpNotFound();
            }
            return View(prodavnica);
        }

        // POST: Prodavnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodavnica prodavnica = db.Prodavnica.Find(id);
            db.Prodavnica.Remove(prodavnica);
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
