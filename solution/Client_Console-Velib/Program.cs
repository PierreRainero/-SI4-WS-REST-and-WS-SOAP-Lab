using System;

namespace Client_Console_Velib{
    class Program{
        static void Main(string[] args){
            Client client = new Client();
            client.availableCmd();
            
            while (client.status)
                client.executeCmd(Console.ReadLine());
        }
    }
}
