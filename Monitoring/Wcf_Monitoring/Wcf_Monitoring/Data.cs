using System;
using System.Collections.Generic;

namespace Wcf_Monitoring
{
    [Serializable]
    class Data
    {
        public IDictionary<DateTime, Request> requests { get; }

        /// <summary>
        /// Construteur par défaut.
        /// </summary>
        public Data(){
            requests = new Dictionary<DateTime, Request>();
        }

        /// <summary>
        /// Ajoute une requête au logs.
        /// </summary>
        /// <param name="date">Date où la requête a été effectuée.</param>
        /// <param name="request">Requête associée.</param>
        public void add(DateTime date, Request request){
            requests.Add(date, request);
            SaverLoader.WriteToBinaryFile<Data>(System.AppDomain.CurrentDomain.BaseDirectory + "/data", this);
        }
    }
}
