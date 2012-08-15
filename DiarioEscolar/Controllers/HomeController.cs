using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiarioEscolar.Helpers;
using DiarioEscolar.Models;
using DiarioEscolar.ViewModels;

namespace DiarioEscolar.Controllers
{
    public class HomeController : Controller
    {
        private DiarioEscolarEntities db = new DiarioEscolarEntities();

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Facilitando o trabalho do Professor.";
            var providerUserKey = UserHelper.CurrentProviderUserKey();
            var anoSeries = (from ano in db.AnoSeries
                                                 where ano.ProviderUserKey == providerUserKey
                                                     && ano.Ano == DateTime.Now.Year
                                                 select new AnoSerieViewModel()
                                                 {
                                                     AnoSerieId = ano.AnoSerieId,                                                     
                                                     Serie = ano.Serie,
                                                     Materias = (from materia in db.Materias
                                                                 where materia.AnoSerie.AnoSerieId == ano.AnoSerieId
                                                                 select new MateriaViewModel()
                                                                 {
                                                                     MateriaId = materia.MateriaId,
                                                                     Descricao = materia.Descricao
                                                                 })
                                                 }).ToList();


            //List<AnoSerieViewModel> anoSeries = (from ano in db.AnoSeries
            //                                     where ano.ProviderUserKey == providerUserKey
            //                                         && ano.Ano == DateTime.Now.Year
            //                                     select new AnoSerieViewModel()
            //                                     {
            //                                         AnoSerieId = ano.AnoSerieId,
            //                                         Serie = ano.Serie,
            //                                         //Materias = db.Materias.Select(a => a.AnoSerie.AnoSerieId == ano.AnoSerieId)
            //                                         Materias = (from materia in db.Materias
            //                                                     where materia.AnoSerie.AnoSerieId == ano.AnoSerieId
            //                                                     select new MateriaViewModel() { Descricao = materia.Descricao })
            //                                     }
            //               ).ToList();

            //var anoSeries = db.AnoSeries.Where(a => a.ProviderUserKey == providerUserKey && a.Ano == DateTime.Now.Year).ToList();

            ViewBag.AnoSeries = anoSeries;

            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Facilitando o trabalho do Professor.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
