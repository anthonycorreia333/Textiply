using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Textiply.Api.Models
{
    public class User : IdentityUser
    {
        // custom fields + relationships go here
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
       
        public virtual ICollection<Audience> Audiences { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}