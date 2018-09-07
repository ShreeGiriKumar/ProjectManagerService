using NBench;
using ProjectManager.DL.DO;
using ProjectManagerPortal.BL;
using ProjectManagerPortal.Controllers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManager.PerfTest
{
    public class ProjectManagerPerfTester
    {
        private const int AcceptableMinAddThroughput = 50;

        private static ProjectController controller = new ProjectController(new ProjectManagerBL(), new UserManagerBL())
        {
            Request = new System.Net.Http.HttpRequestMessage(),
            Configuration = new HttpConfiguration()
        };

        List<ProjectDO> projects = new List<ProjectDO>();

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            for (var cnt = 0; cnt < 100; cnt++)
            {
                projects.Add(new ProjectDO()
                {
                    ProjectId = cnt + 10,
                    ProjectTitle = "Project Title Load" +  cnt,
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date,
                    Priority = 1,
                    ManagerId = 1006 + cnt
                });
            }
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void AddProject_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < projects.Count; i++)
            {
                HttpResponseMessage msg = controller.Post(projects[i]);
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetAllProject_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                HttpResponseMessage msg = controller.Get();
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetProjectById_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                HttpResponseMessage msg = controller.Get(1);
            }
        }


        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {

        }
    }
}

