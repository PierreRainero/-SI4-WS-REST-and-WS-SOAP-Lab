using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Wcf_SOAP_Velib{
    public class VelibOperations : IVelibOperations {
        private static readonly string API_KEY = "f65cdf983437ce5da40eef104ef903fc729da72d";
        private Cache cache = new Cache();

        /// <inheritdoc />
        public IList<string> getCities(){
            IList<string> res = cache.checkCities();
            if (res != null)
                return res;

            return parseCities(getContracts());
        }

        /// <inheritdoc />
        public async Task<IList<string>> getCitiesAsync(){
            IList<string> res = cache.checkCities();
            if (res != null)
                return res;

            Task<string> getContracts = getContractsAsync();
            string contacts = await getContracts;

            return parseCities(contacts);
        }

        private IList<string> parseCities(string contracts){
            JArray jsonArray = null;
            IList<string> res = new List<string>();
            try{
                jsonArray = JArray.Parse(contracts);
            }
            catch (BadRequestException e){
                return res;
            }

            int size = jsonArray.Count;

            for (int i = 0; i < size; i++)
                res.Add((string)((JObject)jsonArray[i])["name"]);

            cache.updateCities(res);

            return res;
        }

        /// <inheritdoc />
        public IList<string> getStations(string city){
            IList<string> res = cache.checkStations(city);
            if (res != null)
                return res;

            return parseStations(city, getDataForCity(city));
        }

        /// <inheritdoc />
        public async Task<IList<string>> getStationsAsync(string city){
            IList<string> res = cache.checkStations(city);
            if (res != null)
                return res;

            Task<string> getCityData = getDataForCityAsync(city);
            string cityData = await getCityData;

            return parseStations(city, cityData);
        }

        private IList<string> parseStations(string city, string cityData){
            JArray jsonArray = null;
            IList<string> res = new List<string>();

            try{
                jsonArray = JArray.Parse(cityData);
            }
            catch (BadRequestException e){
                return res;
            }

            int size = jsonArray.Count;

            for (int i = 0; i < size; i++)
                res.Add((string)((JObject)jsonArray[i])["name"]);

            cache.updateStations(city, res);

            return res;
        }

        /// <inheritdoc />
        public int getAvailableBikes(string city, string station){
            return parseAvailableBikes(getDataForCity(city), station);
        }

        /// <inheritdoc />
        public async Task<int> getAvailableBikesAsync(string city, string station){
            Task<string> getCityData = getDataForCityAsync(city);
            string cityData = await getCityData;

            return parseAvailableBikes(getDataForCity(city), station);
        }

        private int parseAvailableBikes(string cityData, string station){
            JArray jsonArray = null;
            try{
                jsonArray = JArray.Parse(cityData);
            }
            catch (BadRequestException e){
                return -1;
            }
            int size = jsonArray.Count;

            for (int i = 0; i < size; i++)
            {
                var item = (JObject)jsonArray[i];
                if (((string)item["name"]).ToLower().Contains(station.ToLower()))
                    return Convert.ToInt32(item["available_bikes"]);
            }

            return -1;
        }

        private string getContracts(){
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + API_KEY);
            StreamReader reader = null;
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
            }
            catch (Exception e)
            {
                throw new BadRequestException("Failed while trying to get all cities", "");
            }

            return reader.ReadToEnd();
        }

        private Task<string> getContractsAsync(){
            return Task<string>.Run(() => {
                return getContracts();
            });
        }

        private string getDataForCity(string city) {
            string cityName = Char.ToUpper(city[0]) + city.Substring(1, city.Length - 1).ToLower();
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + cityName + "&apiKey=" + API_KEY);
            StreamReader reader = null;
            try {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
            }
            catch (Exception e){
                throw new BadRequestException("Failed while trying to get all stations for a city", cityName);
            }

            return reader.ReadToEnd();
        }

        private Task<string> getDataForCityAsync(string city){
            return Task<string>.Run(() => {
                return getDataForCity(city);
            });
        }

    }
}
