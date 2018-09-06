using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DL.EF;

namespace ProjectManager.DL.DL
{
    public class TaskManagerDL
    {
        public ProjectManagerEntities projectManagerContext = new ProjectManagerEntities();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TaskData> GetAllTasks()
        {
            return projectManagerContext.TaskDatas.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TaskData> GetAllTasksByProjectId(int projectId)
        {
            return projectManagerContext.TaskDatas.Where(x => x.ProjectId == projectId).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public TaskData GetTask(int taskId)
        {
            return projectManagerContext.TaskDatas.Where(x => x.TaskId == taskId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(TaskData taskData)
        {
            projectManagerContext.TaskDatas.Add(taskData);
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(TaskData taskData)
        {
            TaskData task = projectManagerContext.TaskDatas.Where(x => x.TaskId == taskData.TaskId).FirstOrDefault();
            task.TaskTitle = taskData.TaskTitle;
            task.ParentTaskId = taskData.ParentTaskId;
            task.Priority = taskData.Priority;
            task.StartDate = taskData.StartDate;
            task.EndDate = taskData.EndDate;
            task.IsEnded = taskData.IsEnded;
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ParentTask> GetAllParentTasks()
        {
            return projectManagerContext.ParentTasks.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void AddParentTask(ParentTask task)
        {
            projectManagerContext.ParentTasks.Add(task);
            projectManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentTaskId"></param>
        /// <returns></returns>
        public ParentTask GetParentTask(int parentTaskId)
        {
            return projectManagerContext.ParentTasks.Where(x => x.ParentTaskId == parentTaskId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void UpdateParentTask(ParentTask task)
        {
            ParentTask existingData = projectManagerContext.ParentTasks.Where(x => x.ParentTaskId == task.ParentTaskId).FirstOrDefault();

            if(existingData != null)
            {
                existingData.ParentTaskTitle = task.ParentTaskTitle;
            }
            projectManagerContext.SaveChanges();
        }
    }
}
