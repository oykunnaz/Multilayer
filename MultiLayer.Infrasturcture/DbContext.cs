using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MultiLayer.Domain;
using MultiLayer.Domain.Entities;
using MultiLayer.Presentation.Models;

namespace MultiLayer.Infrasturcture
{
    public class MultilayerDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public MultilayerDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Forms> Forms { get; set; }
        public DbSet<fields> fields { get; set; }
    }
}
