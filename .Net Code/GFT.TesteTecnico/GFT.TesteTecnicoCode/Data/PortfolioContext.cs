using GFT.TesteTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GFT.TesteTecnicoCode.Data
{
    public class PortfolioContext: DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; }

        public PortfolioContext() : base("GFT.TesteTecnico")
        {

        }
    }
}