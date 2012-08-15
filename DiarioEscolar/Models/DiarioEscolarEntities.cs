using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DiarioEscolar.Models
{
    public class DiarioEscolarEntities : DbContext
    {
        public DbSet<AnoSerie> AnoSeries { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<NotaFalta> NotaFaltas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();        
        }

        
    }    
}