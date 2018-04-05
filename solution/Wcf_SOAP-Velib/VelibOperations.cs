using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Wcf_SOAP_Velib{
    public class VelibOperations : IVelibOperations {
        private static readonly string API_KEY = "f65cdf983437ce5da40eef104ef903fc729da72d";
        private Cache cache;
        private LogService.LogClient logClient = new LogService.LogClient();
        private TimeSpan responseDelay;

        static Action<string, string, int> m_EventCounter = delegate { };
        private IDictionary<Tuple<string,string>, int> bikes;

        private void getCache(){
            cache = SaverLoader.ReadFromBinaryFile<Cache>(System.AppDomain.CurrentDomain.BaseDirectory + "/cache");
            cache = cache == null ? new Cache() : cache;

            if (bikes == null)
                bikes = new Dictionary<Tuple<string, string>, int>();
        }

        /// <inheritdoc />
        public IList<string> getCities(){
            getCache();
            IList<string> res = cache.checkCities();
            if (res != null) {
                logClient.recordRequest(DateTime.Now, "getCities", true, new TimeSpan());
                return res;
            }


            
            res = parseCities(getContracts());
            logClient.recordRequest(DateTime.Now, "getCities", false, responseDelay);

            return res;
        }

        /// <inheritdoc />
        public async Task<IList<string>> getCitiesAsync(){
            getCache();
            IList<string> res = cache.checkCities();
            if (res != null){
                logClient.recordRequest(DateTime.Now, "getCitiesAsync", true, new TimeSpan());
                return res;
            }

            Task<string> getContracts = getContractsAsync();
            string contacts = await getContracts;

            logClient.recordRequest(DateTime.Now, "getCitiesAsync", false, responseDelay);
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
        public IList<string> getStations(string city) {
            getCache();
            IList<string> res = cache.checkStations(city);
            if (res != null) {
                logClient.recordRequest(DateTime.Now, "getStations", true, new TimeSpan());
                return res;
            }


            res = parseStations(city, getDataForCity(city));
            logClient.recordRequest(DateTime.Now, "getStations", false, responseDelay);

            return res;
        }

        /// <inheritdoc />
        public async Task<IList<string>> getStationsAsync(string city){
            getCache();
            IList<string> res = cache.checkStations(city);
            if (res != null) {
                logClient.recordRequest(DateTime.Now, "getStationsAsync", true, new TimeSpan());
                return res;
            }

            Task<string> getCityData = getDataForCityAsync(city);
            string cityData = await getCityData;

            logClient.recordRequest(DateTime.Now, "getStationsAsync", false, responseDelay);
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
            int outRes;

            int res = parseAvailableBikes(getDataForCity(city), station);
            logClient.recordRequest(DateTime.Now, "getAvailableBikes", false, responseDelay);

            //Si on ne connait pas la valeur alors on l'ajoute pour la garder en mémoire
            if (!bikes.TryGetValue(new Tuple<string, string>(city, station), out outRes))
                bikes.Add(new Tuple<string, string>(city, station), res);
            else if (outRes != res){ //Sinon on va regarder si le nombre de vélos à changer et si c'est le cas notifier le client
                bikes.Add(new Tuple<string, string>(city, station), outRes);
                m_EventCounter(city, station, outRes);
            }

            return res;
        }

        /// <inheritdoc />
        public async Task<int> getAvailableBikesAsync(string city, string station){
            Task<string> getCityData = getDataForCityAsync(city);
            string cityData = await getCityData;

            logClient.recordRequest(DateTime.Now, "getAvailableBikesAsync", false, responseDelay);
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
            DateTime beforeReq = DateTime.Now;
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
            DateTime afterReq = DateTime.Now;
            responseDelay = afterReq-beforeReq;

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
            DateTime beforeReq = DateTime.Now;
            try {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
            }
            catch (Exception e){
                throw new BadRequestException("Failed while trying to get all stations for a city", cityName);
            }
            DateTime afterReq = DateTime.Now;
            responseDelay = afterReq - beforeReq;

            return reader.ReadToEnd();
        }

        private Task<string> getDataForCityAsync(string city){
            return Task<string>.Run(() => {
                return getDataForCity(city);
            });
        }

        public void SubscribeAvailableBikesChanged(string city, string station, int millis){
            IVelibEvent subscriber = OperationContext.Current.GetCallbackChannel<IVelibEvent>();
            m_EventCounter += subscriber.ValueChanged;

            Thread updater = new Thread(new ParameterizedThreadStart(update));
            Tuple<string, Tuple<string, int>> datas = new Tuple<string, Tuple<string, int>>(city, new Tuple<string, int>(station, millis));
            updater.Start(datas);
        }

        private void update(object datas)
        {
            Tuple<string, Tuple<string, int>> datasL = (Tuple<string, Tuple<string, int>>)datas;
            string city = datasL.Item1;
            string station = datasL.Item2.Item1;
            int millis = datasL.Item2.Item2;

            while (true){
                getAvailableBikes(city, station);

                Thread.Sleep(millis);
            }
        }
    }
}
