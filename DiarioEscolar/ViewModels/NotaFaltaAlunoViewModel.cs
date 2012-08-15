using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiarioEscolar.Models;

namespace DiarioEscolar.ViewModels
{
    public class NotaFaltaAlunoViewModel
    {
        public NotaFaltaAlunoViewModel()
        {
            NotaFaltaViewModel = new NotaFaltaViewModel();
        }
        public string DescricaoMateria { get; set; }

        public int MateriaId { get; set; }

        public string NomeAluno { get; set; }

        public int NumeroAluno { get; set; }

        public int AlunoId { get; set; }

        public NotaFaltaViewModel NotaFaltaViewModel { get; set; }

    }

    public class NotaFaltaViewModel
    {
        public int NotaFaltaId { get; set; }

        public decimal Nota1 { get; set; }

        public decimal Falta1 { get; set; }

        public decimal Nota2 { get; set; }

        public decimal Falta2 { get; set; }

        public decimal Nota3 { get; set; }

        public decimal Falta3 { get; set; }

        public decimal Nota4 { get; set; }

        public decimal Falta4 { get; set; }

        public decimal Recuperacao { get; set; }

        public decimal MediaFinal { get; set; }

    }
}