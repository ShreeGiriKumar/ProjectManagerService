using ProjectManager.DL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerPortal.BL
{
    public interface IUserManagerBL
    {
        List<UserDO> GetAllAvailableUsers();
        List<UserDO> GetAllUsers();
        UserDO GetUser(int userId);
        void AddUser(UserDO task);
        void UpdateUser(UserDO task);
        void DeleteUser(int userId);
        void UpdateProjectId(int? userId, int projectId);
        void UpdateTaskId(int? userId, int taskId);
        void DeassignTask(int taskId);
    }
}
