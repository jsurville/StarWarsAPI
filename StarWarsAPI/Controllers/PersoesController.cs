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
using StarWarsAPI.Data;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers
{
    public class PersoesController : ApiController
    {
        private StarWarsAPIContext db = new StarWarsAPIContext();

        // GET: api/Persoes
        public IQueryable<Perso> GetPersos()
        {
            return db.Persos;
        }

        // GET: api/Persoes/5
        [ResponseType(typeof(Perso))]
        public IHttpActionResult GetPerso(int id)
        {
            Perso perso = db.Persos.Find(id);
            if (perso == null)
            {
                return NotFound();
            }

            return Ok(perso);
        }

        // PUT: api/Persoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerso(int id, Perso perso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perso.ID)
            {
                return BadRequest();
            }

            db.Entry(perso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoExists(id))
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

        // POST: api/Persoes
        [ResponseType(typeof(Perso))]
        public IHttpActionResult PostPerso(Perso perso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persos.Add(perso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perso.ID }, perso);
        }

        // DELETE: api/Persoes/5
        [ResponseType(typeof(Perso))]
        public IHttpActionResult DeletePerso(int id)
        {
            Perso perso = db.Persos.Find(id);
            if (perso == null)
            {
                return NotFound();
            }

            db.Persos.Remove(perso);
            db.SaveChanges();

            return Ok(perso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersoExists(int id)
        {
            return db.Persos.Count(e => e.ID == id) > 0;
        }
    }
}