using GFT.TesteTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GFT.TesteTecnicoCode.Data
{
    public class SetorClienteContext: DbContext
    {
        public DbSet<SetorCliente> SetorClientes { get; set; }

        public SetorClienteContext() : base("GFT.TesteTecnico")
        {

        }
    }
}