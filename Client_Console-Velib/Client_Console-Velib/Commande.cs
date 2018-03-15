using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Client_Console_Velib{

    enum CommandeEnum {
        [Description("liste des villes disponibles")]
        CITIES,

        [Description("liste des stations d'une ville donnée")]
        STATIONS,

        [Description("nombre de vélos disponibles pour une station et une ville donnée")]
        AVAILABLE_BIKES,

        [Description("ferme l'application")]
        EXIT,

        [Description("listes des commandes supportées par l'application")]
        HELP,
    };

    class Commande{
        public CommandeEnum cmd { get; }

        private static readonly string AVAILABLE_CMD = "Liste des commandes :\n - " + CommandeEnum.CITIES + " : " + Commande.GetEnumDescription(CommandeEnum.CITIES) + "\n - " + CommandeEnum.STATIONS + " <nom ville> : " + Commande.GetEnumDescription(CommandeEnum.STATIONS) + "\n - " + CommandeEnum.AVAILABLE_BIKES + " <nom ville> <nom station> : " + Commande.GetEnumDescription(CommandeEnum.AVAILABLE_BIKES) + "\n - " + CommandeEnum.EXIT + " : " + Commande.GetEnumDescription(CommandeEnum.EXIT) + "\n - " + CommandeEnum.HELP + " : " + Commande.GetEnumDescription(CommandeEnum.HELP);
        private VelibSOAP.VelibOperationsClient velibClient;
        private string[] args;

        public Commande(CommandeEnum cmd, string[] args){
            velibClient = new VelibSOAP.VelibOperationsClient();

            this.cmd = cmd;
            this.args = args;
        }

        public static void availableCmd(){
            Console.WriteLine(AVAILABLE_CMD);
        }

        public bool execute(){
            switch (cmd){
                case CommandeEnum.CITIES:
                    Console.WriteLine(getCities());
                    break;

                case CommandeEnum.STATIONS:
                    if (args.Length < 1){
                        Console.WriteLine("/!\\ La commande \"STATIONS\" prend un argument");
                        break;
                    }
                    Console.WriteLine(getStations());
                    break;

                case CommandeEnum.AVAILABLE_BIKES:
                    if (args.Length < 2){
                        Console.WriteLine("/!\\ La commande \"AVAILABLE_BIKES\" prend deux arguments");
                        break;
                    }
                    Console.WriteLine(getBikes());
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

        private string getCities(){
            string res = "";
            IList<string> cities = velibClient.getCities();

            foreach (string item in cities)
                res += "\n" + item;

            return res;
        }

        private string getStations(){
            string res = "";
            IList<string> stations = velibClient.getStations(args[0]);

            foreach (string item in stations)
                res += "\n" + item;

            return res;
        }

        private string getBikes(){
            string station = "";
            int size = args.Length;

            for (int i = 1; i < size; i++)
                station += args[i] + " ";
            station = station.Substring(0, station.Length - 1);
            int nbBike = velibClient.getAvailableBikes(args[0], station);

            return "[" + args[0] + ":" + station + "] Vélos disponibles : " + nbBike;
        }

        public static string GetEnumDescription(CommandeEnum value){
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
