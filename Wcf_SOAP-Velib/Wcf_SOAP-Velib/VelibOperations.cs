using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Wcf_SOAP_Velib{
    public class VelibOperations : IVelibOperations {
        private static readonly string API_KEY = "f65cdf983437ce5da40eef104ef903fc729da72d";

        public IList<string> getStations(string city){
            JArray jsonArray = JArray.Parse(getData(city));
            int size = jsonArray.Count;
            IList<string> res = new List<string>();

            for (int i = 0; i < size; i++)
                res.Add((string)((JObject)jsonArray[i])["name"]);

            return res;
        }

        public int getAvailableBikes(string city, string station){
            JArray jsonArray = JArray.Parse(getData(city));
            int size = jsonArray.Count;

            for (int i = 0; i < size; i++){
                var item = (JObject)jsonArray[i];
                if (station.ToLower().Contains(((string)item["name"]).ToLower()))
                    return (int)item["available_bikes"];
            }

            return -1;
        }

        private string getData(string city) {
            string cityName = Char.ToUpper(city[0]) + city.Substring(1, city.Length - 1).ToLower();
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + cityName + "&apiKey=" + API_KEY);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            return reader.ReadToEnd();
        }

    }
}
