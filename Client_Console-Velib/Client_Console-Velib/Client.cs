using System;

namespace Client_Console_Velib{
    class Client{
        private static readonly string separator = "———————————————————————————————————————————————————————————";
        public bool status { get; private set; }

        public Client(){
            status = true;
        }

        /// <summary>
        /// Affiche les commandes disponibles sur la console (sortie standard).
        /// </summary>
        public void availableCmd(){
            Commande.availableCmd();
        }

        /// <summary>
        /// Exécute la commande entrée par l'utilisateur.
        /// </summary>
        /// <param name="cmd">Commande à effectuer telle que l'utilisateur l'a écrite.</param>
        public void executeCmd(string cmd){
            Commande parsedCmd = parseCmd(cmd);

            if (parsedCmd == null)
                Console.WriteLine("<<Commande inconnue : "+ cmd + ">>\n>>> Utilisez HELP <<<");
            else
                status = parsedCmd.execute();

            Console.WriteLine(separator);
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