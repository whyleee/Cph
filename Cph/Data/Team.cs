using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cph.Data
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}