using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client_Console_Monitoring
{

    enum CommandeEnum{
        [Description("journal des logs complet")]
        LOGS,

        [Description("nombre de requêtes effectuées pour une période donnée")]
        NUM_REQUESTS,

        [Description("ferme l'application")]
        EXIT,

        [Description("listes des commandes supportées par l'application")]
        HELP,
    };

    class Commande{
        public CommandeEnum cmd { get; }

        private static readonly string AVAILABLE_CMD = "Liste des commandes (dates sous la forme jj/mm/aaaa) :\n - " + CommandeEnum.LOGS + " : " + Commande.GetEnumDescription(CommandeEnum.LOGS) + "\n - " + CommandeEnum.NUM_REQUESTS + " <date de début> <date de fin> : " + Commande.GetEnumDescription(CommandeEnum.NUM_REQUESTS) + "\n - " + CommandeEnum.EXIT + " : " + Commande.GetEnumDescription(CommandeEnum.EXIT) + "\n - " + CommandeEnum.HELP + " : " + Commande.GetEnumDescription(CommandeEnum.HELP);

        private LogService.LogClient logClient;
        private string[] args;

        public Commande(CommandeEnum cmd, string[] args){
            logClient = new LogService.LogClient();

            this.cmd = cmd;
            this.args = args;
        }

        public static void availableCmd(){
            Console.WriteLine(AVAILABLE_CMD);
        }

        public bool execute(){
            switch (cmd){
                case CommandeEnum.NUM_REQUESTS:
                    if (args.Length < 2){
                        Console.WriteLine("/!\\ La commande \"NUM_REQUESTS\" prend  deux argument");
                        break;
                    }
                    Console.WriteLine(getNumRequests());
                    break;

                case CommandeEnum.LOGS:
                    Console.WriteLine(logClient.getAllLogs());
                    break;

                case CommandeEnum.EXIT:
                    return false;

                case CommandeEnum.HELP:
                    availableCmd();
                    break;

                default:
                    break;
            }

            return true;
        }

        private string getNumRequests(){
            DateTime start;
            DateTime end;
            try
            {
                start = DateTime.ParseExact(args[0], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                end = DateTime.ParseExact(args[1], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return "Format de date : INVALIDE !\nUtilisez le format suivant : jj/mm/aaaa";
            }

            return "Nombre de requêtes : " + logClient.getClientResquests(start, end);
        }

        private static string GetEnumDescription(CommandeEnum value){
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
