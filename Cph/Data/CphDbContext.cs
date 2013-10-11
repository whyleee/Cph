using System.Data.Entity;

namespace Cph.Data
{
    public class CphDb : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<SocialService> SocialServices { get; set; }
    }
}