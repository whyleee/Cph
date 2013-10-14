using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cph.Data;

namespace Cph.Models
{
    public class ProjectListModel
    {
        public IList<Project> Projects { get; set; }
    }
}