using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TesteTecnicoAPI.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string NomePortfolio { get; set; }

        public ICollection<Trade> Trades { get; set; }
    }
}
