using Textiply.Api.Infrastructure;
using Textiply.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using System.Linq;

namespace Textiply.Api.Controllers
{
    public class UsersController : ApiController
    {
        private UserManager<User> _userManager;
#pragma warning disable CS0649 // Field 'UsersController.db' is never assigned to, and will always have its default value null
        private TextiplyDataContext db;
#pragma warning restore CS0649 // Field 'UsersController.db' is never assigned to, and will always have its default value null

        public UsersController()
        {
            var db = new TextiplyDataContext();
            var store = new UserStore<User>(db);

            _userManager = new UserManager<User>(store);
        }

        //Get: api/users
        [Authorize]
        public IHttpActionResult GetUsers()
        {
            var resultSet = db.Users.Select(u => new
            {
                u.Id,
                u.FirstName,
                u.LastName
            });
            return Ok(resultSet);
        }
        //Get: api/users/5
        [Authorize]
        public IHttpActionResult GetUser(string id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.BusinessName,
                Audiences = user.Audiences.Select(a => new
                {
                    a.AudienceId,
                    a.FirstName,
                    a.LastName,
                    a.PhoneNumber,
                    a.City,
                    a.Zip,
                    a.Gender

                }),
               
            });
        }

        //Put: api/users/5
        //Delete: api/users/5

        // POST: api/users/register
        [AllowAnonymous]
        [Route("api/users/register")]
        public IHttpActionResult Register(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = registration.EmailAddress
            };

            var result = _userManager.Create(user, registration.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid user registration");
            }
        }

        protected override void Dispose(bool disposing)
        {
            _userManager.Dispose();
        }
    }
}