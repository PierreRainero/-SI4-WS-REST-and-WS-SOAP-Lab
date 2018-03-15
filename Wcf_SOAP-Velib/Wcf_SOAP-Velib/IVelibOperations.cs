using System.Collections.Generic;
using System.ServiceModel;


namespace Wcf_SOAP_Velib {

    [ServiceContract]
    public interface IVelibOperations {

        /// <summary>
        /// Retourne l'ensemble des villes fournit par l'API JC Decaux.
        /// </summary>
        ///<returns>Une collection de données de type <c>IList</c> dont chaque membre est une string contenant le nom d'une ville.</returns>
        [OperationContract]
        IList<string> getCities();

        /// <summary>
        /// Retourne l'ensemble des stations d'une ville spécifique.
        /// </summary>
        /// <param name="city"> Nom de la ville à consulter (insensible à la casse)</param>
        ///<returns>Une collection de données de type <c>IList</c> dont chaque membre est une string contenant le nom d'une station.</returns>
        [OperationContract]
        IList<string> getStations(string city);

        /// <summary>
        /// Retourne le nombre de vélos disponible pour une station spécifique d'une ville donnée.
        /// </summary>
        /// <param name="city"> Nom de la ville à consulter (insensible à la casse)</param>
        /// <param name="station"> Nom de la station à consulter (insensible à la casse), peut être une sous-chaine de la station à utiliser.</param>
        ///<returns>Un numérique de type <c>int</c> symbolisant les vélos disponibles.</returns>
        [OperationContract]
        int getAvailableBikes(string city, string station);
    }
}
