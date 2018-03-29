using System.IO;

namespace Wcf_SOAP_Velib
{
    class SaverLoader{

        /// <summary>
        /// Permet de créer un fichier binaire pour stocker une classe sérialisable.
        /// </summary>
        /// <typeparam name="T">Type de classe à stocker.</typeparam>
        /// <param name="filePath">Chemin vers le fichier.</param>
        /// <param name="objectToWrite">Objet à écrire.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite){
            using (Stream stream = File.Open(filePath, FileMode.Create)){
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Permet de créer un objet sérialisable à partir d'une fichier binaire.
        /// </summary>
        /// <typeparam name="T">Type de classe à générer.</typeparam>
        /// <param name="filePath">Chemin vers le fichier.</param>
        /// <returns>Objet crée ou null.</returns>
        public static T ReadFromBinaryFile<T>(string filePath){
            if (!File.Exists(filePath))
                return default(T);

            using (Stream stream = File.Open(filePath, FileMode.Open)){
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
