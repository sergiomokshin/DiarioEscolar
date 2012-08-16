using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DiarioEscolar.Models
{
    public class NotaFalta
    {
        [ScaffoldColumn(false)]
        public int NotaFaltaId { get; set; }

        public decimal Nota1{ get; set; }

        public int Falta1 { get; set; }

        public decimal Nota2 { get; set; }

        public int Falta2 { get; set; }

        public decimal Nota3 { get; set; }

        public int Falta3 { get; set; }

        public decimal Nota4 { get; set; }

        public int Falta4 { get; set; }
        
        public decimal Recuperacao { get; set; }
        
        public decimal MediaFinal { get; set; }

        public virtual AnoSerie AnoSerie { get; set; }

        public virtual Materia Materia { get; set; }

        public virtual Aluno Aluno { get; set; }

    }
}