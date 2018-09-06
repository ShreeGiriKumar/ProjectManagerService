using ProjectManager.DL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerPortal.BL
{
    public interface IProjectManagerBL
    {
        List<ProjectDO> GetAllProjects();
        ProjectDO GetProject(int projectId);
        int AddProject(ProjectDO projectDO);
        void UpdateProject(ProjectDO projectDO);
        void DeleteProject(int projectId);
    }
}
