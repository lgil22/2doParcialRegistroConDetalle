using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


using _2doParcial.Entidades;

namespace _2doParcial.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@" Data Source = Llamadas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           modelBuilder.Entity<Llamadas>().HasData(new Llamadas { LlamadaId = 1, Descripcion = "Saliente"});
           modelBuilder.Entity<Llamadas>().HasData(new Llamadas { LlamadaId = 2, Descripcion = "Entrante" });

        }
    }
}
