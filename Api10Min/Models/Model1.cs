using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Api10Min.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Servicios_correo> Servicios_correo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicios_correo>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Servicios_correo>()
                .Property(e => e.Propietario)
                .IsFixedLength();

            modelBuilder.Entity<Servicios_correo>()
                .Property(e => e.Desarrollador)
                .IsFixedLength();
        }
    }
}
