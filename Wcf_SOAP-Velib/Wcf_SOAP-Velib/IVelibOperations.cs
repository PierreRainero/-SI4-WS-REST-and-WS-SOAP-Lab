using System.Collections.Generic;
using System.ServiceModel;


namespace Wcf_SOAP_Velib {
    [ServiceContract]
    public interface IVelibOperations {
        [OperationContract]
        IList<string> getStations(string city);

        [OperationContract]
        int getAvailableBikes(string city, string station);
    }
}
