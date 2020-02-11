using Microsoft.EntityFrameworkCore;
using Parcial1Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1Proyecto.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RLIPRAX\SQLEXPRESS;DataBase=ArticulosDb;Trusted_Connection=true;");
        }
    }
}
