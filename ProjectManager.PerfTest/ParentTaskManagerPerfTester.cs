using NBench;
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

namespace ProjectManager.PerfTest
{
    class ParentTaskManagerPerfTester
    {
        private const int AcceptableMinAddThroughput = 50;

        private static ParentTaskController controller = new ParentTaskController(new TaskManagerBL())
        {
            Request = new System.Net.Http.HttpRequestMessage(),
            Configuration = new HttpConfiguration()
        };

        List<ParentDO> tasks = new List<ParentDO>();

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            for (var cnt = 0; cnt < 100; cnt++)
            {
                tasks.Add(new ParentDO()
                {
                   ParentTaskId = 1,
                   ParentTaskTitle = "Load Parent Task Title" + cnt
                });
            }
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void AddParentTask_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < tasks.Count; i++)
            {
                HttpResponseMessage msg = controller.Post(tasks[i]);
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetAllParentTask_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                HttpResponseMessage msg = controller.Get();
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetParentTaskById_Throughput_IterationMode(BenchmarkContext context)
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
