using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiarioEscolar.Models
{

    public class AnoSerie
    {
        [ScaffoldColumn(false)]
        public int AnoSerieId { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório")]
        public int Ano { get; set; }
        
        [DisplayName("Série")]
        [Required(ErrorMessage = "Série é obrigatória")]
        public string Serie { get; set; }

        public string ProviderUserKey { get; set; }
    }
}