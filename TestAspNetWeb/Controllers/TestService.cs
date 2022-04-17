using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestWeb.Controllers
{
    public class TestService
    {
        public void Sync()
        {
            Console.WriteLine("X1");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("X2");
        }

        public async Task Async()
        {
            Console.WriteLine("X1");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("X2");
        }

        public async Task AsyncWithConfigureAwaitFalse()
        {
            Console.WriteLine("X1");
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            Console.WriteLine("X2");
        }
    }
}