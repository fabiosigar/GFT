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
    public class SetorClientesController : ApiController
    {
        private SetorClienteContext db = new SetorClienteContext();

        // GET: api/SetorClientes
        public IEnumerable<SetorCliente> GetSetorClientes()
        {
            return db.SetorClientes;
        }

        // GET: api/SetorClientes/5
        [ResponseType(typeof(SetorCliente))]
        public IHttpActionResult GetSetorCliente(int id)
        {
            SetorCliente setorCliente = db.SetorClientes.Find(id);
            if (setorCliente == null)
            {
                return NotFound();
            }

            return Ok(setorCliente);
        }

        // PUT: api/SetorClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSetorCliente(int id, SetorCliente setorCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != setorCliente.Id)
            {
                return BadRequest();
            }

            db.Entry(setorCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetorClienteExists(id))
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

        // POST: api/SetorClientes
        [ResponseType(typeof(SetorCliente))]
        public IHttpActionResult PostSetorCliente(SetorCliente setorCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SetorClientes.Add(setorCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = setorCliente.Id }, setorCliente);
        }

        // DELETE: api/SetorClientes/5
        [ResponseType(typeof(SetorCliente))]
        public IHttpActionResult DeleteSetorCliente(int id)
        {
            SetorCliente setorCliente = db.SetorClientes.Find(id);
            if (setorCliente == null)
            {
                return NotFound();
            }

            db.SetorClientes.Remove(setorCliente);
            db.SaveChanges();

            return Ok(setorCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SetorClienteExists(int id)
        {
            return db.SetorClientes.Count(e => e.Id == id) > 0;
        }
    }
}