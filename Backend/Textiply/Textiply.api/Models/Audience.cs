using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Textiply.Api.Models;

namespace Textiply.Api.Models
{
    public class Audience
    {
        [Required]
        public int AudienceId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public int? Gender { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }
}