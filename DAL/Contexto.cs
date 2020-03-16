using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using _2doParcial.Entidades;

namespace _2doParcial.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Users> Users{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@" Data Source = Users.db");
        }

    }
}
