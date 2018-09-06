using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManager.DL.DO;
using ProjectManagerPortal.BL;
using ProjectManagerPortal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectManagerPortal.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            List<UserDO> lstUserDO = new List<UserDO>()
            {
                new UserDO()
                {
                    UserId = 1,
                    EmployeeId = "332281",
                    FirstName ="Shree",
                    LastName ="Giri"
                },
                new UserDO()
                {
                    UserId = 2,
                    EmployeeId = "214181",
                    FirstName ="Rajesh",
                    LastName ="Venkatraman"
                }
            };

            var mock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.GetAllUsers()).Returns(lstUserDO);

            var controller = new UserController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualUsers = controller.Get();
            List<UserDO> resp;
            actualUsers.TryGetContentValue(out resp);
            Assert.AreEqual(lstUserDO.Count, resp.Count);
            Assert.AreEqual(lstUserDO[0].EmployeeId, resp[0].EmployeeId);
            Assert.AreEqual(lstUserDO[0].FirstName + lstUserDO[0].LastName, 
                resp[0].FirstName + resp[0].LastName);
        }

        [TestMethod]
        public void GetUser()
        {
            UserDO userDO = new UserDO()
            {
                UserId = 2,
                EmployeeId = "214181",
                FirstName = "Rajesh",
                LastName = "Venkatraman"
            };

            var mock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.GetUser(2)).Returns(userDO);

            var controller = new UserController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualUsers = controller.Get(2);
            UserDO resp;
            actualUsers.TryGetContentValue(out resp);
            Assert.AreEqual(userDO.EmployeeId, resp.EmployeeId);
            Assert.AreEqual(userDO.FirstName + userDO.LastName,
                resp.FirstName + resp.LastName);
        }

        [TestMethod]
        public void AddUser()
        {
            UserDO userDO = new UserDO()
            {
                UserId = 0,
                EmployeeId = "214181",
                FirstName = "Sundar",
                LastName = "Pichai"
            };

            var mock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.AddUser(userDO));

            var controller = new UserController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualUser = controller.Post(userDO);

            Assert.AreEqual("OK", actualUser.StatusCode.ToString());
        }

        [TestMethod]
        public void UpdateUser()
        {
            UserDO userDO = new UserDO()
            {
                UserId = 1,
                EmployeeId = "214181",
                FirstName = "Sundar Google",
                LastName = "Pichai"
            };

            var mock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.UpdateUser(userDO));

            var controller = new UserController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage updatedUser = controller.Put(userDO.UserId, userDO);

            Assert.AreEqual("OK", updatedUser.StatusCode.ToString());
        }

        [TestMethod]
        public void DeleteUser()
        {
            var mock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.DeleteUser(1));

            var controller = new UserController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage deletedUser = controller.Delete(1);

            Assert.AreEqual("OK", deletedUser.StatusCode.ToString());
        }
    }
}
