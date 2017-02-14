using Textiply.Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Textiply.Api.Infrastructure
{
    public class TextiplyDataContext : IdentityDbContext<User>
    {
        public TextiplyDataContext() : base("Textiply.Api")
        {
            

        }

        
        public IDbSet<Audience> Audiences { get; set; }
        public IDbSet<Message> Messages { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1 user has many audiences
            modelBuilder.Entity<User>()
                        .HasMany(user => user.Audiences)
                        .WithRequired(audience => audience.User)
                        .HasForeignKey(audience => audience.UserId);

                        

            // 1 audience has many messages
            modelBuilder.Entity<Audience>()
                        .HasMany(audience => audience.Messages)
                        .WithRequired(message => message.Audience)
                        .HasForeignKey(message => message.AudienceId)
                        .WillCascadeOnDelete(false);


            
                        
                        

            base.OnModelCreating(modelBuilder);
        }
    }
}