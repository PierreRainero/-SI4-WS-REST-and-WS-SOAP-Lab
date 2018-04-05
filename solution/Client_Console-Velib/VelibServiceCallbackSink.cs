

using System;

namespace Client_Console_Velib
{
    internal class VelibServiceCallbackSink : VelibSOAP.IVelibOperationsCallback
    {
        public void ValueChanged(string city, string station, int value){
            Console.WriteLine("[" + city + " : " + station + "] bikes : " + value);
        }
    }
}
