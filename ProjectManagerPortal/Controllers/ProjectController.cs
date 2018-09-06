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
    public class ProjectController : ApiController
    {
        IProjectManagerBL projectManagerBL = null;
        IUserManagerBL userManagerBL = null;

        public ProjectController(IProjectManagerBL _projectManagerBL, IUserManagerBL _userManagerBL)
        {
            projectManagerBL = _projectManagerBL;
            userManagerBL = _userManagerBL;
        }

        // GET: api/Project
        /// <summary>
        /// To Get All projects
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, projectManagerBL.GetAllProjects());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Project/5
        /// <summary>
        /// To get a Project By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, projectManagerBL.GetProject(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST: api/Project
        public HttpResponseMessage Post([FromBody]ProjectDO projectDO)
        {
            try
            {
                var projectId = projectManagerBL.AddProject(projectDO);
                userManagerBL.UpdateProjectId(projectDO.ManagerId, projectId);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT: api/Project/5
        public HttpResponseMessage Put(int id, [FromBody]ProjectDO projectDO)
        {
            try
            {
                projectManagerBL.UpdateProject(projectDO);
                userManagerBL.UpdateProjectId(projectDO.ManagerId, projectDO.ProjectId);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }
    }
}
