using System;

namespace Wcf_Monitoring
{
    class Log : ILog{
        private Data data;

        private void getData() {
            //data = SaverLoader.ReadFromBinaryFile<Data>(System.AppDomain.CurrentDomain.BaseDirectory + "/data");
            data = data==null? new Data() : data;
        }

        public string getAllLogs(){
            getData();
            string res = "";
            foreach (DateTime dt in data.requests.Keys)
            {
                Request tmp;
                data.requests.TryGetValue(dt, out tmp);
                res += dt + " : " + tmp + "\n";
            }
            return res;
        }

        public void recordRequest(DateTime date, string method, bool dataInCache){
            getData();
            data.add(date, new Request(method, dataInCache));
        }

        public int getClientResquests(DateTime begin, DateTime end){
            getData();
            int res = 0;
            foreach (DateTime dt in data.requests.Keys){
                if (dt.CompareTo(begin) >= 0 && dt.CompareTo(begin) <= 0)
                    res++;
            }

            return res;
        }
    }
}
