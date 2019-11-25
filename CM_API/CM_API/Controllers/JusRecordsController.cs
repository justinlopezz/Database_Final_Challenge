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
    public class JusRecordsController : ApiController
    {
        private DADEntities db = new DADEntities();

        // GET: api/JusRecords
        public IQueryable<JusRecord> GetJusRecords()
        {
            return db.JusRecords;
        }

        // GET: api/JusRecords/5
        [ResponseType(typeof(JusRecord))]
        public IHttpActionResult GetJusRecord(string id)
        {
            JusRecord jusRecord = db.JusRecords.Find(id);
            if (jusRecord == null)
            {
                return NotFound();
            }

            return Ok(jusRecord);
        }

        // PUT: api/JusRecords/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJusRecord(string id, JusRecord jusRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jusRecord.RecordID)
            {
                return BadRequest();
            }

            db.Entry(jusRecord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JusRecordExists(id))
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

        // POST: api/JusRecords
        [ResponseType(typeof(JusRecord))]
        public IHttpActionResult PostJusRecord(JusRecord jusRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JusRecords.Add(jusRecord);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JusRecordExists(jusRecord.RecordID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jusRecord.RecordID }, jusRecord);
        }

        // DELETE: api/JusRecords/5
        [ResponseType(typeof(JusRecord))]
        public IHttpActionResult DeleteJusRecord(string id)
        {
            JusRecord jusRecord = db.JusRecords.Find(id);
            if (jusRecord == null)
            {
                return NotFound();
            }

            db.JusRecords.Remove(jusRecord);
            db.SaveChanges();

            return Ok(jusRecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JusRecordExists(string id)
        {
            return db.JusRecords.Count(e => e.RecordID == id) > 0;
        }
    }
}