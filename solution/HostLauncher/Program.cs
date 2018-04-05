using System;
using System.ServiceModel;
using Wcf_SOAP_Velib;

namespace HostLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(VelibOperations));
            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
            host.Close();
        }
    }
}
