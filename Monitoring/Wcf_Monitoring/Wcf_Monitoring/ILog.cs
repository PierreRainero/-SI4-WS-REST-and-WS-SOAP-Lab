using System;
using System.ServiceModel;

namespace Wcf_Monitoring
{
    [ServiceContract]
    public interface ILog {
        /// <summary>
        /// Ajoute une requête aux logs.
        /// </summary>
        /// <param name="date">Date où la requête a été effectuée.</param>
        /// <param name="method">Nom de la méthode appelée.</param>
        /// <param name="dataInCache">Utilisation du cache ou non.</param>
        /// <param name="delay">Délais de la réponse de l'API REST JC Decaux (si non utlisation du cache).</param>
        [OperationContract]
        void recordRequest(DateTime date, string method, bool dataInCache, TimeSpan delay);

        /// <summary>
        /// Retourne la totalité du journal des logs.
        /// </summary>
        /// <returns>Journal des logs sous la forme d'une chaine de cractère (association date : requête).</returns>
        [OperationContract]
        string getAllLogs();

        /// <summary>
        /// Permet d'obtenir le nombre de requêtes effectuées pour une période donnée.
        /// </summary>
        /// <param name="begin">Date de début pour comptabiliser les requêtes.</param>
        /// <param name="end">Date de fin pour comptabiliser les requêtes.</param>
        /// <returns>Nombre de requêtes trouvées.</returns>
        [OperationContract]
        int getClientResquests(DateTime begin, DateTime end);

        /// <summary>
        /// Permet de calculer le temps moyen de réponse de l'API JC Decaux pour une méthode donnée.
        /// </summary>
        /// <param name="method">Nom de la méthode (sensible à la casse).</param>
        /// <returns>Délais moyen.</returns>
        [OperationContract]
        string getAVGDelayOf(string method);
    }
}
