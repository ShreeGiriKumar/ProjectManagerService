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
    public class ParentTaskControllerTest
    {
        [TestMethod]
        public void GetAllParentTask()
        {
            List<ParentDO> lstParentDO = new List<ParentDO>()
            {
                new ParentDO()
                {
                   ParentTaskId = 1,
                   ParentTaskTitle = "Test Parent Task 1"
                },
                new ParentDO()
                {
                    ParentTaskId = 2,
                    ParentTaskTitle = "Test Parent Task 2"
                },
            };

            var mock = new Mock<ITaskManagerBL>();            
            mock.Setup(service => service.GetAllParentTasks()).Returns(lstParentDO);

            var controller = new ParentTaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Get();
            List<ParentDO> resp;
            actualTasks.TryGetContentValue(out resp);
            Assert.AreEqual(lstParentDO.Count, resp.Count);
            Assert.AreEqual(lstParentDO[0].ParentTaskId, resp[0].ParentTaskId);
            Assert.AreEqual(lstParentDO[0].ParentTaskTitle, resp[0].ParentTaskTitle);
        }

        [TestMethod]
        public void GetParentTask()
        {
            ParentDO parentDO = new ParentDO() {
                ParentTaskId = 1,
                ParentTaskTitle = "Test Parent Task"
            };

            var mock = new Mock<ITaskManagerBL>();
            mock.Setup(service => service.GetParentTask(1)).Returns(parentDO);

            var controller = new ParentTaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Get(1);
            ParentDO resp;
            actualTasks.TryGetContentValue(out resp);            
            Assert.AreEqual(parentDO.ParentTaskId, resp.ParentTaskId);
            Assert.AreEqual(parentDO.ParentTaskTitle, resp.ParentTaskTitle);
        }

        [TestMethod]
        public void AddParentTask()
        {
            ParentDO parentTask =
                  new ParentDO()
                  {
                      ParentTaskId = 1,
                      ParentTaskTitle = "New Parent Task"
                  };

            var mock = new Mock<ITaskManagerBL>();            
            mock.Setup(service => service.AddParentTask(parentTask));

            var controller = new ParentTaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Post(parentTask);

            Assert.AreEqual("OK", actualTasks.StatusCode.ToString());
        }


        [TestMethod]
        public void UpdateTask()
        {
            ParentDO parentTask =
                 new ParentDO()
                 {
                     ParentTaskId = 1,
                     ParentTaskTitle = "Updated Parent Task"
                 };

            var mock = new Mock<ITaskManagerBL>();            
            mock.Setup(service => service.UpdateParentTask(parentTask));

            var controller = new ParentTaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Put(parentTask.ParentTaskId, parentTask);

            Assert.AreEqual("OK", actualTasks.StatusCode.ToString());
        }
    }
}

