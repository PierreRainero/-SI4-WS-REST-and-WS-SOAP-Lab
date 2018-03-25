using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Console_Monitoring
{
    class Program{
        static void Main(string[] args){
            Client client = new Client();
            client.availableCmd();
            while (client.status)
                client.executeCmd(Console.ReadLine());
        }
    }
}
