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
    public class MessagesController : ApiController
    {
        private TextiplyDataContext db = new TextiplyDataContext();

        // GET: api/Messages
        [Authorize]
        public IHttpActionResult GetMessages()
        {
            var resultSet = db.Messages.Select(m => new
            {
                m.MessageId,
                m.Audience.User,
                m.AudienceId,
                m.Created,
                m.Sent,
                m.Text
                


            });
            return Ok(resultSet);
        }

        // GET: api/Messages/5
        [Authorize]
        [ResponseType(typeof(Message))]
        public IHttpActionResult GetMessage(int id)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            var resultSet = db.Messages.Select(m => new
            {
                m.MessageId,
                m.Audience.User,
                m.AudienceId,
                m.Created,
                m.Sent,
                m.Text
            });
            return Ok(resultSet);
        }

        // PUT: api/Messages/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.MessageId)
            {
                return BadRequest();
            }

            var dbMessage = db.Messages.Find(id);
            dbMessage.Audience.User = message.Audience.User;
            dbMessage.AudienceId = message.AudienceId;
            dbMessage.Created = message.Created;
            dbMessage.Sent = message.Sent;
            dbMessage.Text = message.Text;


            db.Entry(message).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        [Authorize]
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messages.Add(message);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = message.MessageId }, message);
        }

        // DELETE: api/Messages/5
        [Authorize]
        [ResponseType(typeof(Message))]
        public IHttpActionResult DeleteMessage(int id)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Messages.Remove(message);
            db.SaveChanges();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return db.Messages.Count(e => e.MessageId == id) > 0;
        }
    }
}