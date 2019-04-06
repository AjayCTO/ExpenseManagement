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
    public class ExpenseController : ApiController
    {
        private ExpenseManagementEntities db = new ExpenseManagementEntities();

        // GET api/Expense
        public IQueryable<Expense> GetExpense()
        {
            return db.Expense;
        }

        // GET api/Expense/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> GetExpense(short id)
        {
            Expense expense = await db.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT api/Expense/5
        public async Task<IHttpActionResult> PutExpense(short id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.ExpenseID)
            {
                return BadRequest();
            }

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
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

        // POST api/Expense
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> PostExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expense.Add(expense);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExpenseExists(expense.ExpenseID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = expense.ExpenseID }, expense);
        }

        // DELETE api/Expense/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> DeleteExpense(short id)
        {
            Expense expense = await db.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            db.Expense.Remove(expense);
            await db.SaveChangesAsync();

            return Ok(expense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseExists(short id)
        {
            return db.Expense.Count(e => e.ExpenseID == id) > 0;
        }
    }
}