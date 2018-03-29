using System;

namespace Wcf_Monitoring
{
    class Log : ILog{
        private Data data;

        /// <inheritdoc />
        private void getData() {
            data = SaverLoader.ReadFromBinaryFile<Data>(System.AppDomain.CurrentDomain.BaseDirectory + "/data");
            data = data==null? new Data() : data;
        }

        /// <inheritdoc />
        public string getAllLogs(){
            getData();
            string res = "";
            foreach (DateTime dt in data.requests.Keys){
                Request tmp;
                data.requests.TryGetValue(dt, out tmp);
                res += dt + " : [" + tmp + "]\n";
            }
            return res;
        }

        /// <inheritdoc />
        public void recordRequest(DateTime date, string method, bool dataInCache, TimeSpan delay){
            getData();
            data.add(date, new Request(method, dataInCache, delay));
        }

        /// <inheritdoc />
        public int getClientResquests(DateTime begin, DateTime end){
            getData();
            int res = 0;
            foreach (DateTime dt in data.requests.Keys){
                if (dt.CompareTo(begin) >= 0 && dt.CompareTo(end) <= 0)
                    res++;
            }

            return res;
        }

        /// <inheritdoc />
        public string getAVGDelayOf(string method){
            getData();
            int nbOfRequests = 0;
            TimeSpan ts = new TimeSpan();

            foreach (DateTime dt in data.requests.Keys){
                Request tmp;
                data.requests.TryGetValue(dt, out tmp);
                if (tmp.method.Equals(method) && !tmp.usedCache){
                    nbOfRequests++;
                    ts += tmp.delay;
                }
            }

            if (nbOfRequests != 0) { 
                ts = new TimeSpan(ts.Ticks / nbOfRequests);
                return "Délais moyen pour la méthode \"" + method + "\" : " + ts;
            } else
                return "Aucune donnée pour cette méthode.";
        }
    }
}
