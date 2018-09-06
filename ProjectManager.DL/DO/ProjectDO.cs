using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DL.DO
{
    public class ProjectDO
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public int Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int NoofTasks { get; set; }
        public int CompletedTasks { get; set; }
    }
}
