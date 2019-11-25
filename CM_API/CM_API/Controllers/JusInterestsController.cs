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
    public class JusInterestsController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusInterests
        public IQueryable<JusInterest> GetJusInterests()
        {
            return db.JusInterests;
        }

        // GET: api/JusInterests/5
        [ResponseType(typeof(JusInterest))]
        public IHttpActionResult GetJusInterest(string id)
        {
            JusInterest jusInterest = db.JusInterests.Find(id);
            if (jusInterest == null)
            {
                return NotFound();
            }

            return Ok(jusInterest);
        }

        // PUT: api/JusInterests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusInterest(string id, JusInterest jusInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusInterest.InterestCode)
            {
                return BadRequest();
            }

            db.Entry(jusInterest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusInterestExists(id))
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

        // POST: api/JusInterests
        [ResponseType(typeof(JusInterest))]
        public IHttpActionResult PostJusInterest(JusInterest jusInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusInterests.Add(jusInterest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusInterestExists(jusInterest.InterestCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusInterest.InterestCode }, jusInterest);
        }

        // DELETE: api/JusInterests/5
        [ResponseType(typeof(JusInterest))]
        public IHttpActionResult DeleteJusInterest(string id)
        {
            JusInterest jusInterest = db.JusInterests.Find(id);
            if (jusInterest == null)
            {
                return NotFound();
            }

            db.JusInterests.Remove(jusInterest);
            db.SaveChanges();

            return Ok(jusInterest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusInterestExists(string id)
        {
            return db.JusInterests.Count(e => e.InterestCode == id) > 0;
        }
    }
}