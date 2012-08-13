using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiarioEscolar.Models
{
    public class Materia
    {
        [ScaffoldColumn(false)]
        public int MateriaId { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao{ get; set; }

        public virtual AnoSerie AnoSerie { get; set; }
    }
}