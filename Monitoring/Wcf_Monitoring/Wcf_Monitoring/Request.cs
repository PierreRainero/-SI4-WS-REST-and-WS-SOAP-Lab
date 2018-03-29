using System;

namespace Wcf_Monitoring
{
    [Serializable]
    class Request {
        public string method { get; }
        public bool usedCache { get; }
        public TimeSpan delay { get; }

        /// <summary>
        /// Constructeur normal d'une requête.
        /// </summary>
        /// <param name="method">Nom de la méthode appelée.</param>
        /// <param name="dataInCache">Utilisation du cache ou non.</param>
        /// <param name="delay">Délais de la réponse de l'API REST JC Decaux (si non utlisation du cache).</param>
        public Request(string method, bool dataInCache, TimeSpan delay) {
            this.method = method;
            usedCache = dataInCache;
            this.delay = delay;
        }

        /// <inheritdoc />
        public override string ToString(){
            return "Request : method=" + method + " cache=" + usedCache + " delay=" + delay;
        }
    }
}
