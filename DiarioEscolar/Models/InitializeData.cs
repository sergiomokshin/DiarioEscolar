using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiarioEscolar.Models
{
    public class InitializeData : DropCreateDatabaseIfModelChanges<DiarioEscolarEntities>
    {
        protected override void Seed(DiarioEscolarEntities context)
        {
            //var tipoNotas = new List<TipoNota>
            //{
            //    new TipoNota {Ordem = 1, Descricao= "1 Bimestre"},
            //    new TipoNota {Ordem = 2, Descricao= "2 Bimestre"},
            //    new TipoNota {Ordem = 3, Descricao= "3 Bimestre"},
            //    new TipoNota {Ordem = 4, Descricao= "4 Bimestre"},
            //    new TipoNota {Ordem = 5, Descricao= "Recuperação"},
            //    new TipoNota {Ordem = 6, Descricao= "Média Final"}
            //};

            //tipoNotas.ForEach(t => context.TipoNotas.Add(t));
        }            
    }
}