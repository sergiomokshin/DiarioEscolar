using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using DiarioEscolar.Models;
using System.Data;
using System.Data.Entity;

namespace DiarioEscolar.AcceptanceTests.StepHelpers
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            var db = new DiarioEscolarEntities();

            var notas = from n in db.NotaFaltas select n;
            foreach (var notaFalta in notas)
            {
                db.NotaFaltas.Remove(notaFalta);
            }

            var materias = from n in db.Materias select n;
            foreach (var materia in materias)
            {
                db.Materias.Remove(materia);
            }

            var alunos = from n in db.Alunos select n;
            foreach (var aluno in alunos)
            {
                db.Alunos.Remove(aluno);
            }

            var anoseries = from n in db.AnoSeries select n;
            foreach (var anoserie in anoseries)
            {
                db.AnoSeries.Remove(anoserie);
            }
            db.SaveChanges();
        }
    }
}
