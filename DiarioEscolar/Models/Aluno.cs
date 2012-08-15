using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiarioEscolar.Models
{

    public class Aluno
    {
        [ScaffoldColumn(false)]
        public int AlunoId { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Número é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        public virtual AnoSerie AnoSerie { get; set; }


    }
}