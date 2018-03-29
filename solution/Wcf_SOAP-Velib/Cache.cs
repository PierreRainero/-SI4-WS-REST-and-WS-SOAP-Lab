using System;
using System.Collections.Generic;

namespace Wcf_SOAP_Velib {
    [Serializable]
    class Cache {
        private Tuple<DateTime, IList<string>> savedCities;
        private IDictionary<string, Tuple<DateTime, IList<string>>> savedStations;
        private TimeSpan duration;

        /// <summary>
        /// Construteur par défaut.
        /// La durée de vie du cache est de 5 minutes.
        /// </summary>
        public Cache(){
            savedCities = null;
            savedStations = new Dictionary<string, Tuple<DateTime, IList<string>>>();
            duration = new TimeSpan(0,5,0);
        }

        /// <summary>
        /// Permet de changer la durée de vie d'une information dans le cache.
        /// </summary>
        /// <param name="duration">Nouvelle durée de vie d'une information dans le cache.</param>
        public void changeCacheDuration(TimeSpan duration){
            this.duration = duration;
        }

        /// <summary>
        /// Controle le cache pour trouver la liste des villes.
        /// </summary>
        /// <returns>null si le délai est dépassé ou que le cache est vide.</returns>
        public IList<string> checkCities(){
            DateTime now = DateTime.Now;

            if (savedCities == null)
                return null;

            if (duration > now - savedCities.Item1)
                return savedCities.Item2;
            else
                savedCities = null;

            return null;
        }

        /// <summary>
        /// Met à jour le cache de la liste des villes.
        /// </summary>
        /// <param name="cities">Nouvelle liste des villes disponibles.</param>
        public void updateCities(IList<string> cities){
            savedCities = new Tuple<DateTime, IList<string>>(DateTime.Now, cities);
            SaverLoader.WriteToBinaryFile<Cache>(System.AppDomain.CurrentDomain.BaseDirectory + "/cache", this);
        }

        /// <summary>
        /// Controle le cache pour trouver la liste des stations d'une ville.
        /// </summary>
        /// <param name="cityName">Nom de la ville à utiliser</param>
        /// <returns>null si le délai est dépassé ou que le cache est vide.</returns>
        public IList<string> checkStations(string cityName){
            Tuple<DateTime, IList<string>> res;
            DateTime now = DateTime.Now;

            if (!savedStations.TryGetValue(cityName, out res)){
                return null;
            }

            if (duration > now-res.Item1)
                return res.Item2;
            else
                savedStations.Remove(cityName);

            return null;
        }

        /// <summary>
        /// Met à jour le cache de la liste des stations d'une ville.
        /// </summary>
        /// <param name="cityName">Nom de la ville à renseigner.</param>
        /// <param name="stations">Nouvelle liste des stations disponibles.</param>
        public void updateStations(string cityName, IList<string> stations){
            savedStations.Add(cityName, new Tuple<DateTime, IList<string>>(DateTime.Now, stations));
            SaverLoader.WriteToBinaryFile<Cache>(System.AppDomain.CurrentDomain.BaseDirectory + "/cache", this);
        }
    }
}
