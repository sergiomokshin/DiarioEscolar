using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DiarioEscolar.Helpers;
using DiarioEscolar.Models;

namespace DiarioEscolar.Controllers
{
    public class AnoSerieController : Controller
    {
        private DiarioEscolarEntities db = new DiarioEscolarEntities();

        //
        // GET: /AnoSerie/
        [Authorize]
        public ActionResult Index()
        {
            var providerUserKey = UserHelper.CurrentProviderUserKey();
            return View(db.AnoSeries.Where(a => a.ProviderUserKey == providerUserKey).ToList());
        }

        //
        // GET: /AnoSerie/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            AnoSerie anoserie = db.AnoSeries.Find(id);
            if (anoserie == null)
            {
                return HttpNotFound();
            }
            return View(anoserie);
        }

        //
        // GET: /AnoSerie/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AnoSerie/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(AnoSerie anoserie)
        {
            if (ModelState.IsValid)
            {
                anoserie.ProviderUserKey = UserHelper.CurrentProviderUserKey();
                db.AnoSeries.Add(anoserie);
                db.SaveChanges();
                return RedirectToAction("Index").Success("Série incluída com sucesso!");
            }

            return View(anoserie);
        }

        //
        // GET: /AnoSerie/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            AnoSerie anoserie = db.AnoSeries.Find(id);
            if (anoserie == null)
            {
                return HttpNotFound();
            }
            return View(anoserie);
        }

        //
        // POST: /AnoSerie/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(AnoSerie anoserie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anoserie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index").Success("Série alterada com sucesso!");
            }
            return View(anoserie);
        }

        //
        // GET: /AnoSerie/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            AnoSerie anoserie = db.AnoSeries.Find(id);
            if (anoserie == null)
            {
                return HttpNotFound();
            }
            return View(anoserie);
        }

        //
        // POST: /AnoSerie/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AnoSerie anoserie = db.AnoSeries.Find(id);
            db.AnoSeries.Remove(anoserie);
            db.SaveChanges();
            return RedirectToAction("Index").Success("Série excluída com sucesso!"); ;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}