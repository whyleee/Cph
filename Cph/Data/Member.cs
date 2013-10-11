using System.Collections.Generic;

namespace Cph.Data
{
    public class Member
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<SocialLink> SocialLinks { get; set; }
    }
}