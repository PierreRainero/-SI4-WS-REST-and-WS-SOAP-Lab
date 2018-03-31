using System;
using ClientSOAP.MathsService;

namespace ClientSOAP
{
    class Program{
        static void Main(string[] args){

            MathsOperationsClient client = new MathsOperationsClient("MathsOperations");
            MathsOperationsClient client2 = new MathsOperationsClient("MathsOperationsAChanged");

            Console.WriteLine(client.Add(100, 101));
            Console.WriteLine(client2.Add(100, 101));

            try{
                Console.WriteLine(client.Divide(100, 0));
            }catch(Exception e){
                Console.WriteLine(e.Data);
            }
            
            Console.ReadLine();
        }
    }
}
