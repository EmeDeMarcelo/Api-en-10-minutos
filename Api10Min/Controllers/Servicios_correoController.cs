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
using Api10Min.Models;

namespace Api10Min.Controllers
{
    public class Servicios_correoController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Servicios_correo
        public IQueryable<Servicios_correo> GetServicios_correo()
        {
            return db.Servicios_correo;
        }

        // GET: api/Servicios_correo/5
        [ResponseType(typeof(Servicios_correo))]
        public IHttpActionResult GetServicios_correo(int id)
        {
            Servicios_correo servicios_correo = db.Servicios_correo.Find(id);
            if (servicios_correo == null)
            {
                return NotFound();
            }

            return Ok(servicios_correo);
        }

        // PUT: api/Servicios_correo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServicios_correo(int id, Servicios_correo servicios_correo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicios_correo.Id)
            {
                return BadRequest();
            }

            db.Entry(servicios_correo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Servicios_correoExists(id))
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

        // POST: api/Servicios_correo
        [ResponseType(typeof(Servicios_correo))]
        public IHttpActionResult PostServicios_correo(Servicios_correo servicios_correo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios_correo.Add(servicios_correo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicios_correo.Id }, servicios_correo);
        }

        // DELETE: api/Servicios_correo/5
        [ResponseType(typeof(Servicios_correo))]
        public IHttpActionResult DeleteServicios_correo(int id)
        {
            Servicios_correo servicios_correo = db.Servicios_correo.Find(id);
            if (servicios_correo == null)
            {
                return NotFound();
            }

            db.Servicios_correo.Remove(servicios_correo);
            db.SaveChanges();

            return Ok(servicios_correo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Servicios_correoExists(int id)
        {
            return db.Servicios_correo.Count(e => e.Id == id) > 0;
        }
    }
}