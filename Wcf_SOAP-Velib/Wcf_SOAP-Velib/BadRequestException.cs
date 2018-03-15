using System;

namespace Wcf_SOAP_Velib{

    /// <summary>
    /// Classe d'exception pour le service SOAP.
    /// Utilisé suite à une requête mal formée.
    /// </summary>
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
