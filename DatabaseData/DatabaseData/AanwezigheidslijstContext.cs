using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseAanmaken2
{
    public class AanwezigheidslijstContext : DbContext
    {
        public AanwezigheidslijstContext() : base("AanwezigheidslijstDatabase") { }
        public DbSet<Tijdsregistraties> Tijdsregistraties { get; set; }
        public DbSet<Opleidingsinformatie> Opleidingsinformatie { get; set; }
        public DbSet<NietOpleidingsDagen>NietOpleidingsDagen { get; set; }
        public DbSet<DocentenOpleidingen> DocentenOpleidingen { get; set; }
        public DbSet<Docenten> Docenten { get; set; }
        public DbSet<DeelnemersOpleidingen> DeelnemersOpleidingen { get; set; }
        public DbSet<Deelnemers> Deelnemers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Auteur>()..HasIndex(a => a.Naam).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
