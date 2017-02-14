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
using Textiply.Api.Infrastructure;
using Textiply.Api.Models;

namespace Textiply.api.Controllers
{
    public class AudiencesController : ApiController
    {
        private TextiplyDataContext db = new TextiplyDataContext();

        // GET: api/Audiences
        [Authorize]
        public IHttpActionResult GetAudiences()
        {
            var ResultSet = db.Audiences.Select(a => new
            {
                a.AudienceId,
                a.UserId,
                a.FirstName,
                a.LastName,
                a.PhoneNumber,
                a.City,
                a.Zip,
                a.Gender

            });

            return Ok(ResultSet);
        }

        // GET: api/Audiences/5
        [Authorize]
        [ResponseType(typeof(Audience))]
        public IHttpActionResult GetAudience(int id)
        {
            Audience audience = db.Audiences.Find(id);
            if (audience == null)
            {
                return NotFound();
            }

            var resultSet = db.Audiences.Select(a => new
            {
                a.AudienceId,
                a.UserId,
                a.FirstName,
                a.LastName,
                a.PhoneNumber,
                a.City,
                a.Zip,
                a.Gender

            });

            return Ok(resultSet);
        }

        // PUT: api/Audiences/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAudience(int id, Audience audience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != audience.AudienceId)
            {
                return BadRequest();
            }

            var dbAudience = db.Audiences.Find(id);
            dbAudience.UserId = audience.UserId;
            dbAudience.FirstName = audience.FirstName;
            dbAudience.LastName = audience.LastName;
            dbAudience.PhoneNumber = audience.PhoneNumber;
            dbAudience.City = audience.City;
            dbAudience.Zip = audience.Zip;
            dbAudience.Gender = audience.Gender;

            db.Entry(audience).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudienceExists(id))
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

        // POST: api/Audiences
        [Authorize]
        [ResponseType(typeof(Audience))]
        public IHttpActionResult PostAudience(Audience audience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Audiences.Add(audience);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = audience.AudienceId }, audience);
        }

        // DELETE: api/Audiences/5
        [Authorize]
        [ResponseType(typeof(Audience))]
        public IHttpActionResult DeleteAudience(int id)
        {
            Audience audience = db.Audiences.Find(id);
            if (audience == null)
            {
                return NotFound();
            }

            db.Audiences.Remove(audience);
            db.SaveChanges();

            return Ok(audience);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AudienceExists(int id)
        {
            return db.Audiences.Count(e => e.AudienceId == id) > 0;
        }
    }
}