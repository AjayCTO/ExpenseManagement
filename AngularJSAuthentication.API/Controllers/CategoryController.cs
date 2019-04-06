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
    public class CategoryController : ApiController
    {
        private ExpenseManagementEntities db = new ExpenseManagementEntities();

        // GET api/Category
        public IQueryable<Category> GetCategory()
        {
            return db.Category;
        }

        // GET api/Category/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(short id)
        {
            Category category = await db.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT api/Category/5
        public async Task<IHttpActionResult> PutCategory(short id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST api/Category
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Category.Add(category);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE api/Category/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(short id)
        {
            Category category = await db.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Category.Remove(category);
            await db.SaveChangesAsync();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(short id)
        {
            return db.Category.Count(e => e.CategoryID == id) > 0;
        }
    }
}