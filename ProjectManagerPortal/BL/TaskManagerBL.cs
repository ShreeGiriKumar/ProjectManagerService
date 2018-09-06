using ProjectManager.DL.DL;
using ProjectManager.DL.DO;
using ProjectManager.DL.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerPortal.BL
{
    public class TaskManagerBL : ITaskManagerBL
    {
        TaskManagerDL taskManagerDL = new TaskManagerDL();
        UserManagerDL userManagerDL = new UserManagerDL();

        /// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        public List<TaskDO> GetAllTasks()
        {
            List<TaskDO> lstTaskDO = new List<TaskDO>();

            taskManagerDL.GetAllTasks().ToList().ForEach(x =>
            {
                lstTaskDO.Add(new TaskDO()
                {
                    TaskId = x.TaskId,
                    TaskTitle = x.TaskTitle,
                    ParentTaskId = x.ParentTaskId == null ? 0 : (int)x.ParentTaskId,
                    ParentTaskTitle = x.ParentTaskId != null ? x.ParentTask.ParentTaskTitle : null,
                    Priority = x.Priority,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsTaskEnded = x.IsEnded,
                    ProjectId = x.ProjectId
                });
            });

            return lstTaskDO;
        }
                
        /// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        public List<TaskDO> GetAllTasksByProjectId(int projectId)
        {
            List<TaskDO> lstTaskDO = new List<TaskDO>();

            taskManagerDL.GetAllTasksByProjectId(projectId).ToList().ForEach(x =>
            {
                lstTaskDO.Add(new TaskDO()
                {
                    TaskId = x.TaskId,
                    TaskTitle = x.TaskTitle,
                    ParentTaskId = x.ParentTaskId == null ? 0 : (int)x.ParentTaskId,
                    ParentTaskTitle = x.ParentTaskId != null ? x.ParentTask.ParentTaskTitle : null,
                    Priority = x.Priority,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsTaskEnded = x.IsEnded,
                    ProjectId = x.ProjectId
                });
            });

            return lstTaskDO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public TaskDO GetTask(int taskId)
        {
            var taskData = taskManagerDL.GetTask(taskId);

            return new TaskDO()
            {
                TaskId = taskData.TaskId,
                TaskTitle = taskData.TaskTitle,
                ParentTaskId = taskData.ParentTaskId == null ? 0 : (int)taskData.ParentTaskId,
                Priority = taskData.Priority,
                StartDate = taskData.StartDate,
                EndDate = taskData.EndDate,
                IsTaskEnded = taskData.IsEnded,
                ParentTaskTitle = taskData.ParentTaskId != null ? taskData.ParentTask.ParentTaskTitle : null,
                ProjectId = taskData.ProjectId,
                UserId = userManagerDL.GetUserId(taskData.TaskId)
            };            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public int AddTask(TaskDO task)
        {
            var taskData = 
            new TaskData()
            {
                TaskTitle = task.TaskTitle,
                ParentTaskId = task.ParentTaskId <= 0 ? null : (int?)task.ParentTaskId,
                ProjectId = task.ProjectId,
                Priority = task.Priority,
                StartDate = task.StartDate == DateTime.MinValue ? (DateTime?)null : task.StartDate,
                EndDate = task.EndDate == DateTime.MinValue ? (DateTime?)null : task.EndDate,
                IsEnded = task.IsTaskEnded
            };

            taskManagerDL.AddTask(taskData);

            return taskData.TaskId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(TaskDO task)
        {
            taskManagerDL.UpdateTask(new TaskData()
            {
                TaskId = task.TaskId,
                TaskTitle = task.TaskTitle,
                ParentTaskId = task.ParentTaskId <= 0 ? null : (int?)task.ParentTaskId,
                Priority = task.Priority,
                StartDate = task.StartDate == DateTime.MinValue ? (DateTime?)null : task.StartDate,
                EndDate = task.EndDate == DateTime.MinValue ? (DateTime?)null : task.EndDate,
                IsEnded = task.IsTaskEnded
            });
        }

        /// <summary>
        /// To get all Parent Tasks
        /// </summary>
        public List<ParentDO> GetAllParentTasks()
        {
            List<ParentDO> lstParentTasks = new List<ParentDO>();
            lstParentTasks.Add(new ParentDO() { ParentTaskId = -1, ParentTaskTitle = "--Select Parent Task--" });

            taskManagerDL.GetAllParentTasks().ForEach(x => 
            {
                lstParentTasks.Add(new ParentDO()
                {
                    ParentTaskId = x.ParentTaskId,
                    ParentTaskTitle = x.ParentTaskTitle
                });
            });
            return lstParentTasks;
        }

       
        /// <summary>
        /// To Update a Parent Task
        /// </summary>
        /// <param name="task"></param>
        public void UpdateParentTask(ParentDO task)
        {
            taskManagerDL.UpdateParentTask(new ParentTask()
            {
                ParentTaskId = task.ParentTaskId,
                ParentTaskTitle = task.ParentTaskTitle
            });
        }

        /// <summary>
        /// To Add a Parent Task
        /// </summary>
        /// <param name="task"></param>
        public int AddParentTask(ParentDO task)
        {
            var newParentTask = new ParentTask() { 
                ParentTaskId = task.ParentTaskId,
                ParentTaskTitle = task.ParentTaskTitle
            };

            taskManagerDL.AddParentTask(newParentTask);

            return newParentTask.ParentTaskId;
        }

        /// <summary>
        /// To get a Parent Task
        /// </summary>
        /// <param name="parentTaskId"></param>
        /// <returns></returns>
        public ParentDO GetParentTask(int parentTaskId)
        {   
            var parentTask = taskManagerDL.GetParentTask(parentTaskId);
            return new ParentDO()
            {
                ParentTaskId = parentTask.ParentTaskId,
                ParentTaskTitle = parentTask.ParentTaskTitle
            };
        }
    }
}