using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoffeeLogAppv1.Models;

namespace CoffeeLogAppv1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CoffeeLogAppv1.Models.Brew>? Brew { get; set; }
    }
}