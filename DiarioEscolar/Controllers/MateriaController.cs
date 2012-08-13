using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiarioEscolar.Models;

namespace DiarioEscolar.Controllers
{
    public class MateriaController : Controller
    {
        private DiarioEscolarEntities db = new DiarioEscolarEntities();

        //
        // GET: /Materia/

        public ActionResult Index(int id)
        {
            var materias = from m in db.Materias
                           select m;
            materias = materias.Where(s => s.AnoSerie.AnoSerieId == id);

            ViewBag.AnoSerieId = id;

            return View(materias);

        }

        //
        // GET: /Materia/Details/5

        public ActionResult Details(int id = 0)
        {
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        //
        // GET: /Materia/Create

        public ActionResult Create(int id)
        {
            ViewBag.AnoSerieId = id;
            return View();
        }

        //
        // POST: /Materia/Create

        [HttpPost]
        public ActionResult Create(Materia materia)
        {
            
            var AnoSerie = db.AnoSeries.Find(materia.AnoSerie.AnoSerieId);
            materia.AnoSerie = AnoSerie;

            db.Materias.Add(materia);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = materia.AnoSerie.AnoSerieId });


         
        }

        //
        // GET: /Materia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnoSerieId = materia.AnoSerie.AnoSerieId;
            return View(materia);
        }

        //
        // POST: /Materia/Edit/5

        [HttpPost]
        public ActionResult Edit(Materia materia)
        {
            var AnoSerie = db.AnoSeries.Find(materia.AnoSerie.AnoSerieId);
            materia.AnoSerie = AnoSerie;

            db.Entry(materia).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = materia.AnoSerie.AnoSerieId });
        }

        //
        // GET: /Materia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        //
        // POST: /Materia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Materia materia = db.Materias.Find(id);
            db.Materias.Remove(materia);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = materia.AnoSerie.AnoSerieId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}