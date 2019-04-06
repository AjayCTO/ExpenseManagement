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
    public class AssetController : ApiController
    {
        private ExpenseManagementEntities db = new ExpenseManagementEntities();

        // GET api/Asset
        public IQueryable<Asset> GetAsset()
        {
            return db.Asset;
        }

        // GET api/Asset/5
        [ResponseType(typeof(Asset))]
        public async Task<IHttpActionResult> GetAsset(short id)
        {
            Asset asset = await db.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }

        // PUT api/Asset/5
        public async Task<IHttpActionResult> PutAsset(short id, Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asset.AssetID)
            {
                return BadRequest();
            }

            db.Entry(asset).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST api/Asset
        [ResponseType(typeof(Asset))]
        public async Task<IHttpActionResult> PostAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asset.Add(asset);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssetExists(asset.AssetID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = asset.AssetID }, asset);
        }

        // DELETE api/Asset/5
        [ResponseType(typeof(Asset))]
        public async Task<IHttpActionResult> DeleteAsset(short id)
        {
            Asset asset = await db.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            db.Asset.Remove(asset);
            await db.SaveChangesAsync();

            return Ok(asset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetExists(short id)
        {
            return db.Asset.Count(e => e.AssetID == id) > 0;
        }
    }
}