using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cph.Data
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Started { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Ended { get; set; }

        [Display(Name = "Top image")]
        [DataType(DataType.Url)]
        public string TopImage { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Info { get; set; }

        public virtual ICollection<Member> DevTeam { get; set; }

        public virtual ICollection<Member> ServiceTeam { get; set; }
    }
}