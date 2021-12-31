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
        private Timer timer60Seconds;
        private Timer timer1Day;


        private readonly IProcessBackgroundService _processBackground;

        public Background(IProcessBackgroundService processBackground)
        {
            _processBackground = processBackground;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {

            timer60Seconds = new Timer(async o =>
            {
                Interlocked.Increment(ref num);

                Console.WriteLine("printing  Drug :" + num);
                _processBackground.BringDrugsOnTime();
            },
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(60)
            );

            timer60Seconds = new Timer(async o =>
            {
                Interlocked.Increment(ref num);

                Console.WriteLine("printing  Water :" + num);
                _processBackground.CheckWaterOnTime();
            },
           null,
           TimeSpan.Zero,
           TimeSpan.FromSeconds(60)
           );

            timer1Day = new Timer(async o =>
            {
                Interlocked.Increment(ref num);

                Console.WriteLine("printing  Expier Drug :" + num);
                _processBackground.CheckExpierDrug();
            },
           null,
           TimeSpan.Zero,
           TimeSpan.FromDays(1)
           );
            timer1Day = new Timer(async o =>
            {
                Interlocked.Increment(ref num);

                Console.WriteLine("printing  Expier Subsecption :" + num);
                _processBackground.CheckExpierSubscription();
            },
          null,
          TimeSpan.Zero,
          TimeSpan.FromDays(1)
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
            timer60Seconds?.Dispose();
        }
    }
}
