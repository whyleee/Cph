using System.Data.Entity;

namespace Cph.Data
{
    public class CphDb : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<SocialService> SocialServices { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var project = modelBuilder.Entity<Project>();

            project.HasMany(p => p.DevTeam).WithMany(m => m.DevProjects);
            project.HasMany(p => p.ServiceTeam).WithMany(m => m.ServiceProjects);
        }
    }
}