namespace Wcf_Monitoring
{
    class Request
    {
        private string method;
        private bool usedCache;

        public Request(string method, bool dataInCache)
        {
            this.method = method;
            usedCache = dataInCache;
        }

        public override string ToString(){
            return "Request : method=" + method + " cache=" + usedCache;
        }
    }
}
