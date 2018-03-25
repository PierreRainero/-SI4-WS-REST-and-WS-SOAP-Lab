using System;
using System.Collections.Generic;

namespace Wcf_Monitoring
{
    [Serializable]
    class Data
    {
        public IDictionary<DateTime, Request> requests { get; }

        public Data(){
            requests = new Dictionary<DateTime, Request>();
        }

        public void add(DateTime date, Request request){
            requests.Add(date, request);
            //SaverLoader.WriteToBinaryFile<Data>(System.AppDomain.CurrentDomain.BaseDirectory + "/data", this);
        }
    }
}
