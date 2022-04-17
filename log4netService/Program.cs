using log4net.Config;
using System;
using System.Collections.Generic;
using log4net.Config;
using Topshelf;

namespace log4netService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            var exitCode = HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.SetServiceName("MyService");
                hostConfigurator.SetDisplayName("My Service");
                hostConfigurator.SetDescription("Does custom logic.");

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.UseLog4Net();

                hostConfigurator.Service<log4net>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(() => new log4net());

                    serviceConfigurator.WhenStarted(service => service.Start());
                    serviceConfigurator.WhenStopped(service => service.Stop());
                });
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}