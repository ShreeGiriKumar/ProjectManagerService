using ProjectManager.DL.DO;
using ProjectManagerPortal.BL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagerPortal.Controllers
{
    public class UserController : ApiController
    {
        IUserManagerBL userManagerBL = null;

        public UserController(IUserManagerBL _userManagerBL)
        {
            userManagerBL = _userManagerBL;
        }

        // GET: api/User
        /// <summary>
        /// To get all users
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, userManagerBL.GetAllUsers());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        // GET: api/User/5
        /// <summary>
        /// To Get an User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, userManagerBL.GetUser(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
        // POST: api/User
        /// <summary>
        /// To add an user
        /// </summary>
        /// <param name="userDO"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]UserDO userDO)
        {
            try
            {
                userManagerBL.AddUser(userDO);
                return Request.CreateResponse(HttpStatusCode.OK, "success");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT: api/User/5
        /// <summary>
        /// To update an user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDO"></param>
        public HttpResponseMessage Put(int id, [FromBody]UserDO userDO)
        {
            try
            {
                userManagerBL.UpdateUser(userDO);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/User/5
        /// <summary>
        /// To delete an user
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                userManagerBL.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
