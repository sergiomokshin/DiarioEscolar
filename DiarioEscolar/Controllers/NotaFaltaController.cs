using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiarioEscolar.Models;
using DiarioEscolar.Helpers;
using DiarioEscolar.ViewModels;

namespace DiarioEscolar.Controllers
{
    public class NotaFaltaController : Controller
    {
        private DiarioEscolarEntities db = new DiarioEscolarEntities();

        //
        // GET: /NotaFalta/

        public ActionResult Index()
        {
            return View(db.NotaFaltas.ToList());
        }

        //
        // GET: /NotaFalta/Details/5

        public ActionResult Details(int id = 0)
        {
            NotaFalta notafalta = db.NotaFaltas.Find(id);
            if (notafalta == null)
            {
                return HttpNotFound();
            }
            return View(notafalta);
        }

        //
        // GET: /NotaFalta/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NotaFalta/Create

        [HttpPost]
        public ActionResult Create(NotaFalta notafalta)
        {
            if (ModelState.IsValid)
            {
                db.NotaFaltas.Add(notafalta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notafalta);
        }

        //
        // GET: /NotaFalta/Edit/5

        public ActionResult Edit(int AnoSerieId, int MateriaId)
        {           
            return View(GridNotas(AnoSerieId, MateriaId));
        }

        private IList<NotaFaltaAlunoViewModel> GridNotas(int AnoSerieId, int MateriaId)
        {
            
            var materia = db.Materias.Find(MateriaId);
            var anoSerie = db.AnoSeries.Find(AnoSerieId);

            var notaFalta = (from alunos in db.Alunos
                             where alunos.AnoSerie.AnoSerieId == AnoSerieId
                             select new NotaFaltaAlunoViewModel()
                             {
                                 AnoSerieId = AnoSerieId,
                                 DescricaoMateria = materia.Descricao,
                                 MateriaId = MateriaId,
                                 NomeAluno = alunos.Nome,
                                 NumeroAluno = alunos.Numero,
                                 AlunoId = alunos.AlunoId,
                                 NotaFaltaViewModel = (from notafalta in db.NotaFaltas.DefaultIfEmpty()
                                                       where notafalta.Aluno.AlunoId == alunos.AlunoId
                                                       && notafalta.Materia.MateriaId == MateriaId
                                                       select new NotaFaltaViewModel()
                                                       {

                                                           NotaFaltaId = notafalta.NotaFaltaId,
                                                           Nota1 = notafalta.Nota1,
                                                           Falta1 = notafalta.Falta1,
                                                           Nota2 = notafalta.Nota2,
                                                           Falta2 = notafalta.Falta2,
                                                           Nota3 = notafalta.Nota3,
                                                           Falta3 = notafalta.Falta3,
                                                           Nota4 = notafalta.Nota4,
                                                           Falta4 = notafalta.Falta4,
                                                           Recuperacao = notafalta.Recuperacao,
                                                           MediaFinal = notafalta.MediaFinal
                                                       }).FirstOrDefault()

                             }).ToList();
            //ViewBag.NotaFalta = notaFalta;
            ViewBag.Materia = materia;
            ViewBag.AnoSerie = anoSerie;


            ViewBag.notaFaltaDefault = new NotaFaltaViewModel()
            {
                Nota1 = 0,
                Falta1 = 0,
                Nota2 = 0,
                Falta2 = 0,
                Nota3 = 0,
                Falta3 = 0,
                Nota4 = 0,
                Falta4 = 0,
                Recuperacao = 0,
                MediaFinal = 0
            };

            return notaFalta;
        }

        //
        // POST: /NotaFalta/Edit/5

        [HttpPost]
        public ActionResult Edit(IEnumerable<NotaFaltaAlunoViewModel> notas)
        {
            //TODO: Receber pela ViewModel principal
            int AnoSerieId = 0;
            int MateriaId = 0;
            foreach (var nota in notas)
            {
                AnoSerieId = nota.AnoSerieId;
                MateriaId = nota.MateriaId;

                NotaFalta notaFalta;
                if (nota.NotaFaltaViewModel.NotaFaltaId > 0)
                {
                    notaFalta = db.NotaFaltas.Find(nota.NotaFaltaViewModel.NotaFaltaId);
                    AtribuiNotaFalta(notaFalta, nota.NotaFaltaViewModel);
                    db.Entry(notaFalta).State = EntityState.Modified;
                }
                else
                {
                    notaFalta = new NotaFalta();
                    Aluno aluno = db.Alunos.Find(nota.AlunoId);
                    Materia materia = db.Materias.Find(nota.MateriaId);
                    AnoSerie anoSerie = db.AnoSeries.Find(nota.AnoSerieId);

                    notaFalta.Aluno = aluno;
                    notaFalta.Materia = materia;
                    notaFalta.AnoSerie = anoSerie;

                    AtribuiNotaFalta(notaFalta, nota.NotaFaltaViewModel);
                    db.NotaFaltas.Add(notaFalta);
                
                }

            }

            db.SaveChanges();

            return View(GridNotas(AnoSerieId, MateriaId)).Success("Notas alteradas com sucesso!");
        }

        //
        // GET: /NotaFalta/Delete/5

        private void AtribuiNotaFalta(NotaFalta notaFalta, NotaFaltaViewModel notaFaltaViewModel)
        {

            notaFalta.Nota1 = notaFaltaViewModel.Nota1;
            notaFalta.Falta1 = notaFaltaViewModel.Falta1;
            notaFalta.Nota2 = notaFaltaViewModel.Nota2;
            notaFalta.Falta2 = notaFaltaViewModel.Falta2;
            notaFalta.Nota3 = notaFaltaViewModel.Nota3;
            notaFalta.Falta3 = notaFaltaViewModel.Falta3;
            notaFalta.Nota4 = notaFaltaViewModel.Nota4;
            notaFalta.Falta4 = notaFaltaViewModel.Falta4;

            notaFalta.Recuperacao = notaFaltaViewModel.Recuperacao;

            if(notaFalta.Recuperacao > 0)
                notaFalta.MediaFinal = notaFalta.Recuperacao;
            else
                notaFalta.MediaFinal = (notaFalta.Nota1 + notaFalta.Nota2 + notaFalta.Nota3 + notaFalta.Nota4)/4;

        }

        public ActionResult Delete(int id = 0)
        {
            NotaFalta notafalta = db.NotaFaltas.Find(id);
            if (notafalta == null)
            {
                return HttpNotFound();
            }
            return View(notafalta);
        }

        //
        // POST: /NotaFalta/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NotaFalta notafalta = db.NotaFaltas.Find(id);
            db.NotaFaltas.Remove(notafalta);
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