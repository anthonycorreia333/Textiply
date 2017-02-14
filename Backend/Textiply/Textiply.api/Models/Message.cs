using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Textiply.Api.Models;

namespace Textiply.Api.Models
{
    public class Message
    {
        [Required]
        public int MessageId { get; set; }
        [Required]
        public int AudienceId { get; set; }      
        public DateTime Created { get; set; }
        public DateTime Sent { get; set; }
        [Required]
        public string Text { get; set; }
        public virtual User User { get; set; }
        public virtual Audience Audience { get; set; }
    }
}