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
                Console.WriteLine("printing  Drug " );
                Console.WriteLine("printing  Water " );
                _processBackground.BringDrugsOnTime();
                _processBackground.CheckWaterOnTime();
            },
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(60)
            );


            timer1Day = new Timer(async o =>
            {
                Console.WriteLine("printing Expier Subsecption");
                Console.WriteLine("printing  Expier Drug");
                _processBackground.CheckExpierDrug();
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
            timer1Day?.Dispose();
        }
    }
}
