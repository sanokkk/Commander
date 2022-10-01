using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.DAL
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
