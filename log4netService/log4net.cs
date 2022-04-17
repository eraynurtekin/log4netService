using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace log4netService
{
    public class log4net
    {

        private readonly Timer _timer;

        public log4net()
        {
            _timer = new Timer(1000) { AutoReset = true };

            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };

            File.AppendAllLines(@"C:\temp\my-windows-service\logs\log4net.txt", lines);
        }


        public void Start()
        {
            
        }

        public void Stop()
        {
           
        }
    }
}
