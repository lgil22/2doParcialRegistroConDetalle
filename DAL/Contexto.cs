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

    /* modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 1, Descripcion = "chocolate", Precio = 100 }); modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 2, Descripcion = "cafe", Precio = 100 });

            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 3, Descripcion = "arroz", Precio = 100 }); */

        }
    }
}
