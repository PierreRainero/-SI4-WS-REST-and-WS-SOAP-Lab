using System;
using System.ServiceModel;

namespace ConsoleClient
{
    class Program{
        static void Main(string[] args){
            CalcServiceCallbackSink objsink = new CalcServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);
            CalcServiceReference.CalcServiceClient objClient = new CalcServiceReference.CalcServiceClient(iCntxt);
            objClient.SubscribeValueChanged();
            objClient.Incr();
            objClient.Incr();
            objClient.Incr();
            objClient.Incr();
            objClient.Incr();
            objClient.Decr();
            objClient.Incr();

            Console.ReadLine();
        }
    }
}