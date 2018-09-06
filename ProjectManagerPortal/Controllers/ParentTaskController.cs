using ProjectManager.DL.DO;
using ProjectManagerPortal.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagerPortal.Controllers
{
    public class ParentTaskController : ApiController
    {
        ITaskManagerBL taskManagerBL = null;

        public ParentTaskController(ITaskManagerBL _taskManagerBL)
        {
            taskManagerBL = _taskManagerBL;
        }

        // GET: api/ParentTask
        /// <summary>
        /// To get all parent tasks
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetAllParentTasks());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/ParentTask/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetParentTask(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST: api/ParentTask
        public HttpResponseMessage Post([FromBody]ParentDO parentDO)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.AddParentTask(parentDO));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT: api/ParentTask/5
        public HttpResponseMessage Put(int id, [FromBody]ParentDO parentDO)
        {
            try
            {
                taskManagerBL.UpdateParentTask(parentDO);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/ParentTask/5
        public void Delete(int id)
        {
        }
    }
}
