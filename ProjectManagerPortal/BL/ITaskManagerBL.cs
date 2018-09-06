using ProjectManager.DL.DO;
using System.Collections.Generic;

namespace ProjectManagerPortal.BL
{
    public interface ITaskManagerBL
    {
        List<TaskDO> GetAllTasks();
        List<TaskDO> GetAllTasksByProjectId(int projectId);
        TaskDO GetTask(int taskId);
        int AddTask(TaskDO task);
        void UpdateTask(TaskDO task);
        List<ParentDO> GetAllParentTasks();
        void UpdateParentTask(ParentDO task);
        int AddParentTask(ParentDO task);
        ParentDO GetParentTask(int parentTaskId);

    }
}