using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DL.DO
{
    public class TaskDO
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public int ParentTaskId { get; set; }
        public string ParentTaskTitle { get; set; }
        public int ProjectId { get; set; }
        public int Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsTaskEnded { get; set; }
        public int? UserId { get; set; }
    }
}
