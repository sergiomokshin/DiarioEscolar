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

        public int AnoSerieId { get; set; }

        public string DescricaoMateria { get; set; }

        public int MateriaId { get; set; }

        public string NomeAluno { get; set; }

        public int NumeroAluno { get; set; }

        public int AlunoId { get; set; }

        public NotaFaltaViewModel NotaFaltaViewModel { get; set; }

    }

    public class NotaFaltaViewModel
    {
        public int? NotaFaltaId { get; set; }

        private decimal _Nota1;
        public decimal Nota1
        {
            get {return Math.Round(_Nota1, 1);}

            set { _Nota1 = value; }
        }
        public int Falta1{ get; set; }

        private decimal _Nota2;
        public decimal Nota2
        {
            get { return Math.Round(_Nota2, 2); }

            set { _Nota2 = value; }
        }
        public int Falta2 { get; set; }

        private decimal _Nota3;
        public decimal Nota3
        {
            get { return Math.Round(_Nota3, 3); }

            set { _Nota3 = value; }
        }
        public int Falta3 { get; set; }

        private decimal _Nota4;
        public decimal Nota4
        {
            get { return Math.Round(_Nota4, 4); }

            set { _Nota4 = value; }
        }
        public int Falta4 { get; set; }


        public decimal Recuperacao { get; set; }

        public int TotalFaltas
        {
            get
            {
                return Falta1 + Falta2 + Falta3 + Falta4;
            }
        }

        public decimal MediaFinal { get; set; }

    }
}