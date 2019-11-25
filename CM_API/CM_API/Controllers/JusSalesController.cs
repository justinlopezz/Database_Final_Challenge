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
using CM_API.Models;

namespace CM_API.Controllers
{
    public class JusSalesController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusSales
        public IQueryable<JusSale> GetJusSales()
        {
            return db.JusSales;
        }

        // GET: api/JusSales/5
        [ResponseType(typeof(JusSale))]
        public IHttpActionResult GetJusSale(DateTime id)
        {
            JusSale jusSale = db.JusSales.Find(id);
            if (jusSale == null)
            {
                return NotFound();
            }

            return Ok(jusSale);
        }

        // PUT: api/JusSales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusSale(DateTime id, JusSale jusSale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusSale.DateOrdered)
            {
                return BadRequest();
            }

            db.Entry(jusSale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusSaleExists(id))
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

        // POST: api/JusSales
        [ResponseType(typeof(JusSale))]
        public IHttpActionResult PostJusSale(JusSale jusSale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusSales.Add(jusSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusSaleExists(jusSale.DateOrdered))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusSale.DateOrdered }, jusSale);
        }

        // DELETE: api/JusSales/5
        [ResponseType(typeof(JusSale))]
        public IHttpActionResult DeleteJusSale(DateTime id)
        {
            JusSale jusSale = db.JusSales.Find(id);
            if (jusSale == null)
            {
                return NotFound();
            }

            db.JusSales.Remove(jusSale);
            db.SaveChanges();

            return Ok(jusSale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusSaleExists(DateTime id)
        {
            return db.JusSales.Count(e => e.DateOrdered == id) > 0;
        }
    }
}