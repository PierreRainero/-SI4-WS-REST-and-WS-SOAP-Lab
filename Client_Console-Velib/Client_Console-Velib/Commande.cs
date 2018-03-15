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
    };

    class Commande{
        private static readonly string AVAILABLE_CMD = "Liste des commandes :\n - " + CommandeEnum.CITIES + " : " + Commande.GetEnumDescription(CommandeEnum.CITIES) + "\n - " + CommandeEnum.STATIONS + " <nom ville> : " + Commande.GetEnumDescription(CommandeEnum.STATIONS) + "\n - " + CommandeEnum.AVAILABLE_BIKES + " <nom ville><nom station> : " + Commande.GetEnumDescription(CommandeEnum.AVAILABLE_BIKES) + "\n - " + CommandeEnum.EXIT + " : " + Commande.GetEnumDescription(CommandeEnum.EXIT);
        private VelibSOAP.VelibOperationsClient velibClient;
        public CommandeEnum cmd { get; }
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
                    if (args.Length != 1){
                        availableCmd();
                        break;
                    }
                    Console.WriteLine(getStations(args[0]));
                    break;

                case CommandeEnum.AVAILABLE_BIKES:
                    if (args.Length != 2){
                        availableCmd();
                        break;
                    }
                    Console.WriteLine(getBikes(args[0], args[1]));
                    break;

                case CommandeEnum.EXIT:
                    return false;

                default:
                    availableCmd();
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

        private string getStations(string city){
            string res = "";
            IList<string> stations = velibClient.getStations(city);

            foreach (string item in stations)
                res += "\n" + item;

            return res;
        }

        private string getBikes(string city, string station){
            int nbBike = velibClient.getAvailableBikes(city, station);

            return "[" + city + ":" + station + "]Vélos disponibles : " + nbBike;
        }

        public static string GetEnumDescription(CommandeEnum value){
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
