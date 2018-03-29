using System;
using System.ComponentModel;
using System.Reflection;

namespace Client_Console_Monitoring
{
    /// <summary>
    /// Enumeration de toutes les commandes existantes de l'application.
    /// </summary>
    enum CommandeEnum{
        [Description("journal des logs complet")]
        LOGS,

        [Description("nombre de requêtes effectuées pour une période donnée")]
        NUM_REQUESTS,

        [Description("temps moyen de réponse de l'API JC Decaux pour une méthode")]
        AVG_DELAY,

        [Description("ferme l'application")]
        EXIT,

        [Description("listes des commandes supportées par l'application")]
        HELP,
    };

    class Commande{
        public CommandeEnum cmd { get; }

        private static readonly string AVAILABLE_CMD = "Liste des commandes (dates sous la forme jj/mm/aaaa) :\n - " + CommandeEnum.LOGS + " : " + Commande.GetEnumDescription(CommandeEnum.LOGS) + "\n - " + CommandeEnum.NUM_REQUESTS + " <date de début> <date de fin> : " + Commande.GetEnumDescription(CommandeEnum.NUM_REQUESTS) + "\n - " + CommandeEnum.AVG_DELAY + " <nom de la method> : " + Commande.GetEnumDescription(CommandeEnum.AVG_DELAY) + "\n - " + CommandeEnum.EXIT + " : " + Commande.GetEnumDescription(CommandeEnum.EXIT) + "\n - " + CommandeEnum.HELP + " : " + Commande.GetEnumDescription(CommandeEnum.HELP);

        private LogService.LogClient logClient;
        private string[] args;

        /// <summary>
        /// Constructeur normal.
        /// </summary>
        /// <param name="cmd">Commande à effectuer.</param>
        /// <param name="args">Arguments pour la commande à effectuer.</param>
        public Commande(CommandeEnum cmd, string[] args){
            logClient = new LogService.LogClient();

            this.cmd = cmd;
            this.args = args;
        }

        /// <summary>
        /// Affiche les commandes disponibles sur la console (sortie standard).
        /// </summary>
        public static void availableCmd(){
            Console.WriteLine(AVAILABLE_CMD);
        }

        /// <summary>
        /// Exécute la commande à effectuer.
        /// </summary>
        /// <returns>Le status du client de type <c>bool</c>. Vaut <c>false</c> si le client doit être arrêté.</returns>
        public bool execute(){
            switch (cmd){
                case CommandeEnum.LOGS:
                    Console.WriteLine(logClient.getAllLogs());
                    break;

                case CommandeEnum.NUM_REQUESTS:
                    if (args.Length < 2){
                        Console.WriteLine("/!\\ La commande \"NUM_REQUESTS\" prend  deux argument");
                        break;
                    }
                    Console.WriteLine(getNumRequests());
                    break;

                case CommandeEnum.AVG_DELAY:
                    if (args.Length < 1){
                        Console.WriteLine("/!\\ La commande \"NUM_REQUESTS\" prend  un argument");
                        break;
                    }
                    Console.WriteLine(getDelay());
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

        private string getDelay(){
            switch (args[0]){
                case "getCities":
                    return logClient.getAVGDelayOf(args[0]);

                case "getCitiesAsync":
                    return logClient.getAVGDelayOf(args[0]);

                case "getStations":
                    return logClient.getAVGDelayOf(args[0]);

                case "getStationsAsync":
                    return logClient.getAVGDelayOf(args[0]);

                case "getAvailableBikes":
                    return logClient.getAVGDelayOf(args[0]);

                case "getAvailableBikesAsync":
                    return logClient.getAVGDelayOf(args[0]);

                default:
                    return "Nom de methode invalide, utilisez : \n\tgetCities\n\tgetCitiesAsync\n\tgetStations\n\tgetStationsAsync\n\tgetAvailableBikes\n\tgetAvailableBikesAsync";
            }
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
