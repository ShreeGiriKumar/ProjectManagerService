using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.DL.DL;
using ProjectManager.DL.DO;
using ProjectManager.DL.EF;

namespace ProjectManagerPortal.BL
{
    public class ProjectManagerBL : IProjectManagerBL
    {
        ProjectManagerDL projectManagerDL = new ProjectManagerDL();        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectDO"></param>
        public int AddProject(ProjectDO projectDO)
        {
            var project = new Project() { 
                ProjectId = projectDO.ProjectId,
                ProjectTitle = projectDO.ProjectTitle,
                StartDate = projectDO.StartDate,
                EndDate = projectDO.EndDate,
                Priority = projectDO.Priority                
            };

            projectManagerDL.AddProject(project);
            
            return project.ProjectId;           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectDO"></param>
        public void UpdateProject(ProjectDO projectDO)
        {
            projectManagerDL.UpdateProject(new Project
            {
                ProjectId = projectDO.ProjectId,
                ProjectTitle = projectDO.ProjectTitle,
                StartDate = projectDO.StartDate,
                EndDate = projectDO.EndDate,
                Priority = projectDO.Priority
            });    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProjectDO> GetAllProjects()
        {
            List<ProjectDO> lstProjectDO = new List<ProjectDO>();

            projectManagerDL.GetAllProjects().ForEach(x => 
            {
                lstProjectDO.Add(new ProjectDO() {
                    ProjectId = x.ProjectId,
                    ProjectTitle = x.ProjectTitle,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ManagerId = x.Users.Where(y => y.ProjectId == x.ProjectId).Select(y => y.UserId).FirstOrDefault(),
                    ManagerName = x.Users.Where(y => y.ProjectId == x.ProjectId).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault(),
                    Priority = x.Priority,
                    NoofTasks = projectManagerDL.GetTaskCountForProject(x.ProjectId),
                    CompletedTasks = projectManagerDL.GetCompletedTaskCountForProject(x.ProjectId)
                });
            });
            return lstProjectDO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ProjectDO GetProject(int projectId)
        {
            var projectData = projectManagerDL.GetProject(projectId);

            return new ProjectDO() {
                ProjectId = projectData.ProjectId,
                ProjectTitle = projectData.ProjectTitle,
                Priority = projectData.Priority,
                StartDate = projectData.StartDate,
                EndDate = projectData.EndDate,
                ManagerId = projectData.Users.Where(y=>y.ProjectId == projectData.ProjectId).Select(y => y.UserId).FirstOrDefault(),
                ManagerName = projectData.Users.Where(y => y.ProjectId == projectData.ProjectId).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault()
            };
        }

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        public void DeleteProject(int projectId)
        {
            projectManagerDL.DeleteProject(projectId);
        }
    }
}