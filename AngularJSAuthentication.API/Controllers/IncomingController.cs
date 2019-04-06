using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AngularJSAuthentication.API;

namespace AngularJSAuthentication.API.Controllers
{
    public class IncomingController : ApiController
    {
        private ExpenseManagementEntities db = new ExpenseManagementEntities();

        // GET api/Incoming
        public IQueryable<Incoming> GetIncoming()
        {
            return db.Incoming;
        }

        // GET api/Incoming/5
        [ResponseType(typeof(Incoming))]
        public async Task<IHttpActionResult> GetIncoming(short id)
        {
            Incoming incoming = await db.Incoming.FindAsync(id);
            if (incoming == null)
            {
                return NotFound();
            }

            return Ok(incoming);
        }

        // PUT api/Incoming/5
        public async Task<IHttpActionResult> PutIncoming(short id, Incoming incoming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incoming.IncomeID)
            {
                return BadRequest();
            }

            db.Entry(incoming).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomingExists(id))
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

        // POST api/Incoming
        [ResponseType(typeof(Incoming))]
        public async Task<IHttpActionResult> PostIncoming(Incoming incoming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incoming.Add(incoming);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IncomingExists(incoming.IncomeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = incoming.IncomeID }, incoming);
        }

        // DELETE api/Incoming/5
        [ResponseType(typeof(Incoming))]
        public async Task<IHttpActionResult> DeleteIncoming(short id)
        {
            Incoming incoming = await db.Incoming.FindAsync(id);
            if (incoming == null)
            {
                return NotFound();
            }

            db.Incoming.Remove(incoming);
            await db.SaveChangesAsync();

            return Ok(incoming);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncomingExists(short id)
        {
            return db.Incoming.Count(e => e.IncomeID == id) > 0;
        }
    }
}