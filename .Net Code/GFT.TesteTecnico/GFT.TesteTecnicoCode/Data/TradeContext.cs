using GFT.TesteTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GFT.TesteTecnicoAPI.Data
{
    public class TradeContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }

        public TradeContext() : base("GFT.TesteTecnico")
        {

        }
    }
}