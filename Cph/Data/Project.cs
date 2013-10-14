using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cph.Data
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Started { get; set; }

        public DateTime? Ended { get; set; }

        public string TopImage { get; set; }

        public string Info { get; set; }

        public virtual ICollection<Member> DevTeam { get; set; }

        public virtual ICollection<Member> ServiceTeam { get; set; }
    }
}