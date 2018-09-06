using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.DL.DL;
using ProjectManager.DL.DO;
using ProjectManager.DL.EF;


namespace ProjectManagerPortal.BL
{
    public class UserManagerBL : IUserManagerBL
    {
        UserManagerDL userManagerDL = new UserManagerDL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<UserDO> IUserManagerBL.GetAllUsers()
        {
            List<UserDO> lstUserDO = new List<UserDO>();

            userManagerDL.GetAllUsers().ForEach(x=>
            {
                lstUserDO.Add(new UserDO
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserId = x.UserId,
                    TaskId = x.TaskId ?? 0
                });
            });

            return lstUserDO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserDO> GetAllAvailableUsers()
        {
            List<UserDO> lstUserDO = new List<UserDO>();

            userManagerDL.GetAllAvailableUsers().ForEach(x =>
            {
                lstUserDO.Add(new UserDO
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserId = x.UserId
                });
            });

            return lstUserDO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserDO IUserManagerBL.GetUser(int userId)
        {
            var user = userManagerDL.GetUser(userId);

            return new UserDO()
            {
                UserId = user.UserId,
                EmployeeId = user.EmployeeId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void AddUser(UserDO user)
        {
            userManagerDL.AddUser(new User
            {
                UserId = user.UserId,
                EmployeeId = user.EmployeeId,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserDO user)
        {
            userManagerDL.UpdateUser(new User
            {
                UserId = user.UserId,
                EmployeeId = user.EmployeeId,
                FirstName = user.FirstName,
                LastName = user.LastName
            });            
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(int userId)
        {
            userManagerDL.DeleteUser(userId);
        }

        /// <summary>
        /// Assign Project Id to User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projectId"></param>
        public void UpdateProjectId(int? userId, int projectId)
        {
            userManagerDL.UpdateProjectId(userId, projectId);
        }

        /// <summary>
        /// Assign Task Id to User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskid"></param>
        public void UpdateTaskId(int? userId, int taskId)
        {
            userManagerDL.UpdateTaskId(userId, taskId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        public void DeassignTask(int taskId)
        {
            userManagerDL.DeassignTask(taskId);
        }
    }
}