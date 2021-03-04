using GFT.TesteTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GFT.TesteTecnicoCode.Data
{
    public class CategoriaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public CategoriaContext() : base("GFT.TesteTecnico")
        {

        }
    }
}