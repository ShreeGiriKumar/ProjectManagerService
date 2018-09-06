using ProjectManager.DL.DO;
using ProjectManagerPortal.BL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ProjectManagerPortal.Controllers
{
    public class TaskController : ApiController
    {
        ITaskManagerBL taskManagerBL = null;
        IUserManagerBL userManagerBL = null;

        public TaskController(ITaskManagerBL _taskManagerBL, IUserManagerBL _userManagerBL)
        {
            taskManagerBL = _taskManagerBL;
            userManagerBL = _userManagerBL;
        }

        // GET api/<controller>
        /// <summary>
        /// To Get All The Tasks
        /// </summary>
        /// <returns></returns>        
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetAllTasks());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetAllTaskByProj(int projectId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetAllTasksByProjectId(projectId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        // GET api/<controller>/5
        /// <summary>
        /// /// To Get Task by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetTask(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        // POST api/<controller>        
        /// <summary>
        /// To Add a new Task
        /// </summary>
        /// <param name="taskDO"></param>
        public HttpResponseMessage Post([FromBody]TaskDO taskDO)
        {
            try
            {
                var taskId = taskManagerBL.AddTask(taskDO);
                //Parent task are not associated to an user
                if (taskDO.UserId != null)
                {
                    userManagerBL.UpdateTaskId(taskDO.UserId, taskId);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
                
        // PUT api/<controller>/5
        /// <summary>
        /// To Update an existing Task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskDO"></param>
        /// <returns></returns>                
        public HttpResponseMessage Put(int id, [FromBody]TaskDO taskDO)
        {
            try
            {
                taskManagerBL.UpdateTask(taskDO);
                if (taskDO.IsTaskEnded)
                {
                    userManagerBL.DeassignTask(taskDO.TaskId);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}