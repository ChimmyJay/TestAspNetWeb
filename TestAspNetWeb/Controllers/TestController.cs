using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class TestController : Controller
    {
        private TestService _testService;

        public TestController()
        {
            _testService = new TestService();
        }

        // GET
        public ActionResult Index()
        {
            return new EmptyResult();
        }

        public async Task<ActionResult> AsyncWithAsync()
        {
            Console.WriteLine("A1");
            await Task.CompletedTask;
            Console.WriteLine("A2");
            await _testService.Async();
            Console.WriteLine("A3");
            return new EmptyResult();
        }

        public async Task<ActionResult> AsyncWithSync()
        {
            Console.WriteLine("A1");
            await Task.CompletedTask;
            Console.WriteLine("A2");
            _testService.Sync();
            Console.WriteLine("A3");
            return new EmptyResult();
        }

        public ActionResult SyncWithSync()
        {
            Console.WriteLine("S1");
            _testService.Sync();
            Console.WriteLine("S2");
            return new EmptyResult();
        }

        public ActionResult SyncWithAsync()
        {
            Console.WriteLine("S1");
            _testService.Async().GetAwaiter().GetResult();
            Console.WriteLine("S2");
            return new EmptyResult();
        }

        public ActionResult SyncWithAsyncWithConfigureAwaitFalse()
        {
            Console.WriteLine("S1");
            _testService.AsyncWithConfigureAwaitFalse().GetAwaiter().GetResult();
            Console.WriteLine("S2");
            return new EmptyResult();
        }
    }
}