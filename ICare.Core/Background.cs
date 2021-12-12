using ICare.Core.IServices;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICare.Core
{
    public class Background : IHostedService,IDisposable
    {
        private int num = 0;
        private Timer timer;
        private readonly IProcessBackground _processBackground;

        public Background(IProcessBackground processBackground)
        {
            _processBackground = processBackground;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {

            timer = new Timer(async o =>
            {
                Interlocked.Increment(ref num);

                Console.WriteLine("printing  worker :"+ num);
                _processBackground.BringDrugsOnTime();
            },
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(60)
            );
           

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("printing  worker stoping");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
