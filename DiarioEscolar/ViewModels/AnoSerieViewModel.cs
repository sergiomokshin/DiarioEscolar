using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiarioEscolar.ViewModels
{
    public class AnoSerieViewModel
    {
        public int AnoSerieId { get; set; }
        public string Serie { get; set; }
        public IEnumerable<MateriaViewModel> Materias {get; set;}

    }

    public class MateriaViewModel
    {    
        public int MateriaId { get; set; }
        public string Descricao{ get; set; }
    }

}