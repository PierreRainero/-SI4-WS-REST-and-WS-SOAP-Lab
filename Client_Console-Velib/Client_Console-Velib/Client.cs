using System;

namespace Client_Console_Velib{
    class Client{
        public bool status { get; private set; }

        public Client(){
            status = true;
        }

        public void availableCmd(){
            Commande.availableCmd();
        }

        public void executeCmd(string cmd){
            Commande parsedCmd = parseCmd(cmd);

            if (parsedCmd == null){
                Console.WriteLine("<<Commande inconnue : "+ cmd + ">>\n--- Utilisez HELP ---");
                return;
            }

            status = parsedCmd.execute();
        }

        private Commande parseCmd(string cmd){
            Commande res = null;
            CommandeEnum c;
            string[] parts;
            string[] sep = { " " };

            if(cmd == "")
                return res;

            parts = cmd.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (Enum.IsDefined(typeof(CommandeEnum), parts[0].ToUpper()))
                c = (CommandeEnum)Enum.Parse(typeof(CommandeEnum), parts[0].ToUpper());
            else
                return res;
            
            int partsSize = parts.Length;
            string[] args = new string[partsSize - 1];

            for (int i = 1; i < partsSize; i++)
                args[i - 1] = parts[i];

            res = new Commande(c, args);

            return res;
        }
    }
}