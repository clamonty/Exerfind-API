using Exerfind.Models;
using Microsoft.EntityFrameworkCore;

namespace Exerfind.Data
{
    public class ExerfindContext : DbContext
    {
        // Constructor for our ef DbContext
        // Pass in parameter DbContextOptions of type ExerfindContext
        // Make call to base(super) constructor and pass it options
        public ExerfindContext(DbContextOptions<ExerfindContext> opt) : base(opt)
        {

        }

        // Use a DbSet property of type Exercise to add a Exercises table to our database
        public DbSet<Exercise> Exercises { get; set; }
    }
}