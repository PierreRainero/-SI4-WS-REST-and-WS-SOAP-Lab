using System;

namespace Wcf_SOAP_Velib{
    class BadRequestException : Exception {
        private string parameter;

        public BadRequestException(string message, string parameter) : base(message){
            this.parameter = parameter;
        }

        public override string ToString(){
            return "BadRequestException: " + this.Message + " Parameter:" + parameter;
        }
    }
}
