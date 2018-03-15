using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Wcf_SOAP_Velib{
    public class VelibOperations : IVelibOperations {
        private static readonly string API_KEY = "f65cdf983437ce5da40eef104ef903fc729da72d";

        public IList<string> getCities(){
            JArray jsonArray = null;
            IList<string> res = new List<string>();

            try{
                jsonArray = JArray.Parse(getContracts());
            }
            catch (BadRequestException e){
                return res;
            }

            int size = jsonArray.Count;

            for (int i = 0; i < size; i++)
                res.Add((string)((JObject)jsonArray[i])["name"]);

            return res;
        }

        public IList<string> getStations(string city){
            JArray jsonArray = null;
            IList<string> res = new List<string>();

            try{
                jsonArray = JArray.Parse(getDataForCity(city));
            } catch(BadRequestException e){
                return res;
            }
            
            int size = jsonArray.Count;

            for (int i = 0; i < size; i++)
                res.Add((string)((JObject)jsonArray[i])["name"]);
            
            return res;
        }

        public int getAvailableBikes(string city, string station){
            JArray jsonArray = null;
            try{
                jsonArray = JArray.Parse(getDataForCity(city));
            } catch(BadRequestException e){
                return -1;
            }
            int size = jsonArray.Count;

            for (int i = 0; i < size; i++){
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

    }
}
