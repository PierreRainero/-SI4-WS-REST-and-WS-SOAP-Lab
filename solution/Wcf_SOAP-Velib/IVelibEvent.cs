using System.ServiceModel;

namespace Wcf_SOAP_Velib
{
    interface IVelibEvent
    {
        [OperationContract(IsOneWay = true)]
        void ValueChanged(string city, string station, int value);
    }
}
