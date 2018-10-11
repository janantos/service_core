using System;
using System.ServiceProcess;
using System.Threading;
using System.Diagnostics;
using System.Reflection;



namespace service_core
{
    static class ServiceInfo
    {
        static public string SVC_APP_NAME = "MyService_core";
        static public string SVC_EXECUTABLE_PATH = Assembly.GetExecutingAssembly().Location.Remove(Assembly.GetExecutingAssembly().Location.Length - 4) + ".exe";
    }
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var cmd = args[0];
                if(cmd.Equals("-u"))
                {
                    var processStop = new Process();
                    var startInfoStop = new ProcessStartInfo();
                    startInfoStop.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfoStop.FileName = "sc.exe";
                    Console.WriteLine("Stopping Service");
                    startInfoStop.Arguments = "stop " + ServiceInfo.SVC_APP_NAME;
                    processStop.StartInfo = startInfoStop;
                    processStop.Start();
                    processStop.WaitForExit();
                    Console.WriteLine("Service uninstall");

                    var process = new Process();
                    var startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "sc.exe";
                    startInfo.Arguments = "delete " + ServiceInfo.SVC_APP_NAME;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                }
                else if (cmd.Equals("-i"))
                {
                    var process = new Process();
                    var startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "sc.exe";
                    startInfo.Arguments = string.Format("create {0} displayname=\"{1}\" binpath=\"{2}\"",ServiceInfo.SVC_APP_NAME, ServiceInfo.SVC_APP_NAME, ServiceInfo.SVC_EXECUTABLE_PATH);
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                }
                else if (cmd.Equals("-h"))
                {
                    Console.WriteLine(string.Format("{0}",ServiceInfo.SVC_APP_NAME));
                    Console.WriteLine("Options:");
                    Console.WriteLine("  -i\tInstall Service");
                    Console.WriteLine("  -u\tUninstall Service");
                    Console.WriteLine("  -h\tShow command line switch help");

                }
                else
                {
                    Console.WriteLine(string.Format("{0}",ServiceInfo.SVC_APP_NAME));
                    Console.WriteLine("Options:");
                    Console.WriteLine("  -i\tInstall Service");
                    Console.WriteLine("  -u\tUninstall Service");
                    Console.WriteLine("  -h\tShow command line switch help");
                }
            }
            else
            {
                ServiceBase.Run(new MyService());
            }
            

            
        }
    }

    class MyService : ServiceBase
    {
        public MyService ()
        {
            this.AutoLog = false;
            this.CanHandlePowerEvent = true;
            this.CanPauseAndContinue = false;
            this.CanShutdown = true;
            this.ServiceName = "MyService";
        }

        protected override bool  OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return true;
        }

        protected override void OnStart(string[] args)
        {
            // add your code
        }

        protected override void OnStop()
        {
            // add your code
            
        }

        protected override void OnShutdown()
        {
            // add your code
        }
    }
}
