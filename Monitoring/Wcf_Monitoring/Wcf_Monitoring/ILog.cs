using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Wcf_Monitoring
{
    [ServiceContract]
    public interface ILog {
        [OperationContract]
        void recordRequest(DateTime date, string method, bool dataInCache);

        [OperationContract]
        string getAllLogs();

        [OperationContract]
        int getClientResquests(DateTime begin, DateTime end);
    }
}
