﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiarioEscolar.Helpers;
using DiarioEscolar.Models;

namespace DiarioEscolar.Controllers
{
    public class AlunoController : Controller
    {
        private DiarioEscolarEntities db = new DiarioEscolarEntities();

        //
        // GET: /Aluno/

        public ActionResult Index(int id)
        {
            var alunos = from m in db.Alunos
                           select m;
            alunos = alunos.Where(s => s.AnoSerie.AnoSerieId == id);

            ViewBag.AnoSerieId = id;

            return View(alunos);

        }

        //
        // GET: /Aluno/Details/5

        public ActionResult Details(int id = 0)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnoSerieId = aluno.AnoSerie.AnoSerieId;
            return View(aluno);
        }

        //
        // GET: /Aluno/Create

        public ActionResult Create(int id)
        {
            ViewBag.AnoSerieId = id;
            return View();
        }

        //
        // POST: /Aluno/Create

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {

            var AnoSerie = db.AnoSeries.Find(aluno.AnoSerie.AnoSerieId);
            aluno.AnoSerie = AnoSerie;

            db.Alunos.Add(aluno);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = aluno.AnoSerie.AnoSerieId }).Success("Aluno incluído com sucesso!");

        }

        //
        // GET: /Aluno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnoSerieId = aluno.AnoSerie.AnoSerieId;
            return View(aluno);
        }

        //
        // POST: /Aluno/Edit/5

        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            var AnoSerie = db.AnoSeries.Find(aluno.AnoSerie.AnoSerieId);
            aluno.AnoSerie = AnoSerie;

            db.Entry(aluno).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = aluno.AnoSerie.AnoSerieId }).Success("Aluno alterado com sucesso!");

        }

        //
        // GET: /Aluno/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnoSerieId = aluno.AnoSerie.AnoSerieId;
            return View(aluno);
        }

        //
        // POST: /Aluno/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index").Success("Aluno excluído com sucesso!");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}