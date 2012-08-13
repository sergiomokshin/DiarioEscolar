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
    public class AlunoController : Controller
    {
        private DiarioEscolarEntities db = new DiarioEscolarEntities();

        //
        // GET: /Aluno/

        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
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
            return View(aluno);
        }

        //
        // GET: /Aluno/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Aluno/Create

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
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
            return View(aluno);
        }

        //
        // POST: /Aluno/Edit/5

        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
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
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}