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
    public class UserManagerPerfTester
    {
        private const int AcceptableMinAddThroughput = 50;

        private static UserController controller = new UserController(new UserManagerBL())
        {
            Request = new System.Net.Http.HttpRequestMessage(),
            Configuration = new HttpConfiguration()
        };

        List<UserDO> users = new List<UserDO>();

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            for (var cnt = 0; cnt < 50; cnt++)
            {
                users.Add(new UserDO()
                {
                    TaskId = 0,
                    UserId = cnt,
                    EmployeeId = string.Format("{0}-{1}", "Emp Id", cnt),
                    FirstName = string.Format("{0}-{1}", "First Name", cnt),
                    LastName = string.Format("{0}-{1}", "Last Name", cnt),
                });
            }
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void AddUser_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < users.Count; i++)
            {
                HttpResponseMessage msg = controller.Post(users[i]);
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetAllUser_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                HttpResponseMessage msg = controller.Get();
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetUserById_Throughput_IterationMode(BenchmarkContext context)
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
