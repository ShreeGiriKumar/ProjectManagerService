using ProjectManager.DL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DL.DL
{
    public class ProjectManagerDL
    {
        public ProjectManagerEntities projectManagerContext = new ProjectManagerEntities();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAllProjects()
        {
            return projectManagerContext.Projects.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public Project GetProject(int projectId)
        {
            return projectManagerContext.Projects.Where(x => x.ProjectId == projectId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        public void AddProject(Project project)
        {
            projectManagerContext.Projects.Add(project);
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        public void UpdateProject(Project project)
        {
            Project existingData = projectManagerContext.Projects.Where(x => x.ProjectId == project.ProjectId).FirstOrDefault();
            if (existingData != null)
            {
                existingData.Priority = project.Priority;
                existingData.ProjectTitle = project.ProjectTitle;
                existingData.StartDate = project.StartDate;
                existingData.EndDate = project.EndDate;                
            }
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        public void DeleteProject(int projectId)
        {
            Project project = projectManagerContext.Projects.Where(x => x.ProjectId == projectId).FirstOrDefault();
            projectManagerContext.Projects.Remove(project);
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public int GetTaskCountForProject(int projectId)
        {
            return projectManagerContext.TaskDatas.Where(x => x.ProjectId == projectId).Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public int GetCompletedTaskCountForProject(int projectId)
        {
            return projectManagerContext.TaskDatas.Where(x => x.ProjectId == projectId && x.IsEnded).Count();
        }
    }
}

