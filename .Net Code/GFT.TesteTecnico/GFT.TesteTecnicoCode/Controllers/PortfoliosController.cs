using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GFT.TesteTecnicoAPI.Models;
using GFT.TesteTecnicoCode.Data;

namespace GFT.TesteTecnicoCode.Controllers
{
    public class PortfoliosController : ApiController
    {
        private PortfolioContext db = new PortfolioContext();

        // GET: api/Portfolios
        public IEnumerable<Portfolio> GetPortfolios()
        {
            return db.Portfolios;
        }

        // GET: api/Portfolios/5
        [ResponseType(typeof(Portfolio))]
        public IHttpActionResult GetPortfolio(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        // PUT: api/Portfolios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPortfolio(int id, Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != portfolio.Id)
            {
                return BadRequest();
            }

            db.Entry(portfolio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Portfolios
        [ResponseType(typeof(Portfolio))]
        public IHttpActionResult PostPortfolio(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Portfolios.Add(portfolio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = portfolio.Id }, portfolio);
        }

        // DELETE: api/Portfolios/5
        [ResponseType(typeof(Portfolio))]
        public IHttpActionResult DeletePortfolio(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            db.Portfolios.Remove(portfolio);
            db.SaveChanges();

            return Ok(portfolio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PortfolioExists(int id)
        {
            return db.Portfolios.Count(e => e.Id == id) > 0;
        }
    }
}