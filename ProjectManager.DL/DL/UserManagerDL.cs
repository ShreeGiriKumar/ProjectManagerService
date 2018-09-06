using ProjectManager.DL.DO;
using ProjectManager.DL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DL.DL
{
    public class UserManagerDL
    {
        public ProjectManagerEntities projectManagerContext = new ProjectManagerEntities();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return projectManagerContext.Users.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllAvailableUsers()
        {
            return projectManagerContext.Users.Where(x => x.TaskId == null).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            return projectManagerContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        public void AddUser(User user)
        {
            projectManagerContext.Users.Add(user);
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        public void UpdateUser(User user)
        {
            User existingData = projectManagerContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if(existingData != null)
            {
                existingData.EmployeeId = user.EmployeeId;
                existingData.FirstName = user.FirstName;
                existingData.LastName = user.LastName;
            }
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        public void DeleteUser(int userId)
        {
            User user = projectManagerContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            projectManagerContext.Users.Remove(user);
            projectManagerContext.SaveChanges();
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projectId"></param>
        public void UpdateProjectId(int? userId, int projectId)
        {
            User existingData = projectManagerContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            if (existingData != null)
            {
                existingData.ProjectId = projectId;                    
            }
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        public void UpdateTaskId(int? userId, int taskId)
        {
            User existingData = projectManagerContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            if (existingData != null)
            {
                existingData.TaskId = taskId;
            }
            projectManagerContext.SaveChanges();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        public void DeassignTask(int taskId)
        {
            User existingData = projectManagerContext.Users.Where(x => x.TaskId == taskId).FirstOrDefault();
            if (existingData != null)
            {
                existingData.TaskId = null;
            }
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public int GetUserId(int taskId)
        {
            return projectManagerContext.Users.Where(x => x.TaskId == taskId).Select(x => x.UserId).FirstOrDefault();
        }
    }
}
