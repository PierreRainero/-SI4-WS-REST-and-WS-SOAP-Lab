using System;
using System.ServiceModel;

namespace MathsLibrary
{
    [ServiceContract]
    public interface IMathsOperations{
        [OperationContract]
        int Add(int num1, int num2);

        [OperationContract]
        int Multiply(int num1, int num2);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        int Divide(int num1, int num2);
    }

}
