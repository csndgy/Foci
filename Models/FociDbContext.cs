using Microsoft.EntityFrameworkCore;


namespace focisokadik.Models

{
    public class FociDbContext: DbContext
    {
        public FociDbContext
            (DbContextOptions<FociDbContext> options) : base(options) { }

        public DbSet<Meccs> Meccsek { get; set; }
    }
}
