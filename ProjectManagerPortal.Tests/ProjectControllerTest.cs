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
    public class ProjectControllerTest
    {
        [TestMethod]
        public void GetAllProjects()
        {
            List<ProjectDO> lstProjectDO = new List<ProjectDO>()
            {
                new ProjectDO()
                {
                    ProjectTitle= "Cloud Transformation",
                    ProjectId = 9,
                    CompletedTasks = 1,
                    NoofTasks = 3,
                    ManagerId = 1,
                    ManagerName = "Daniel",
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddDays(3),
                    Priority = 1                    
                },
                new ProjectDO()
                {
                    ProjectTitle= "AAS Web Transformation",
                    ProjectId = 1,
                    CompletedTasks = 0,
                    NoofTasks = 4,
                    ManagerId = 2,
                    ManagerName = "John",
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddDays(10),
                    Priority = 2
                },
            };

            var mock = new Mock<IProjectManagerBL>();
            var userMock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.GetAllProjects()).Returns(lstProjectDO);

            var controller = new ProjectController(mock.Object, userMock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualProjects = controller.Get();
            List<ProjectDO> resp;
            actualProjects.TryGetContentValue(out resp);
            Assert.AreEqual(lstProjectDO.Count, resp.Count);
            Assert.AreEqual(lstProjectDO[0].ProjectTitle, resp[0].ProjectTitle);
        }

        [TestMethod]
        public void GetProject()
        {
            ProjectDO projectDO =
            new ProjectDO()
            {
                ProjectTitle = "AAS Web Transformation",
                ProjectId = 1,
                CompletedTasks = 0,
                NoofTasks = 4,
                ManagerId = 2,
                ManagerName = "John",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(10),
                Priority = 2
            };

            var mock = new Mock<IProjectManagerBL>();
            var userMock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.GetProject(1)).Returns(projectDO);

            var controller = new ProjectController(mock.Object, userMock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualProject = controller.Get(1);
            ProjectDO resp;
            actualProject.TryGetContentValue(out resp);
            Assert.IsNotNull(resp);
            Assert.AreEqual(projectDO.ProjectTitle, resp.ProjectTitle);
            Assert.AreSame(projectDO, resp);
        }

        [TestMethod]
        public void AddTask()
        {
            ProjectDO project =
                  new ProjectDO()
                  {
                      ProjectTitle = "ELM",
                      StartDate = DateTime.Now.Date,
                      EndDate = DateTime.Now.Date.AddDays(100),
                      Priority = 1,          
                      ManagerId = 5,
                      ManagerName = "Richard",
                      ProjectId = 0
                  };

            var mock = new Mock<IProjectManagerBL>();
            var userMock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.AddProject(project));
            userMock.Setup(service => service.UpdateProjectId(project.ManagerId, 0));

            var controller = new ProjectController(mock.Object, userMock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualAddProject = controller.Post(project);

            Assert.AreEqual("OK", actualAddProject.StatusCode.ToString());
        }


        [TestMethod]
        public void UpdateTask()
        {
            ProjectDO project =
                   new ProjectDO()
                   {
                       ProjectTitle = "ELM",
                       StartDate = DateTime.Now.Date,
                       EndDate = DateTime.Now.Date.AddDays(100),
                       Priority = 1,
                       ManagerId = 5,
                       ManagerName = "Richard",
                       ProjectId = 1
                   };

            var mock = new Mock<IProjectManagerBL>();
            var userMock = new Mock<IUserManagerBL>();
            mock.Setup(service => service.UpdateProject(project));
            userMock.Setup(service => service.UpdateProjectId(project.ManagerId, 1));

            var controller = new ProjectController(mock.Object, userMock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualUpdateProject = controller.Put(project.ProjectId, project);

            Assert.AreEqual("OK", actualUpdateProject.StatusCode.ToString());
        }
    }
}
