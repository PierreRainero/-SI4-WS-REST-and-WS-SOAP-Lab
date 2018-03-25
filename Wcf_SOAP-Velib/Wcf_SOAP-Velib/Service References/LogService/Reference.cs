﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wcf_SOAP_Velib.LogService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LogService.ILog")]
    public interface ILog {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/recordRequest", ReplyAction="http://tempuri.org/ILog/recordRequestResponse")]
        void recordRequest(System.DateTime date, string method, bool dataInCache);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/recordRequest", ReplyAction="http://tempuri.org/ILog/recordRequestResponse")]
        System.Threading.Tasks.Task recordRequestAsync(System.DateTime date, string method, bool dataInCache);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getAllLogs", ReplyAction="http://tempuri.org/ILog/getAllLogsResponse")]
        string getAllLogs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getAllLogs", ReplyAction="http://tempuri.org/ILog/getAllLogsResponse")]
        System.Threading.Tasks.Task<string> getAllLogsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getClientResquests", ReplyAction="http://tempuri.org/ILog/getClientResquestsResponse")]
        int getClientResquests(System.DateTime begin, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getClientResquests", ReplyAction="http://tempuri.org/ILog/getClientResquestsResponse")]
        System.Threading.Tasks.Task<int> getClientResquestsAsync(System.DateTime begin, System.DateTime end);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILogChannel : Wcf_SOAP_Velib.LogService.ILog, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogClient : System.ServiceModel.ClientBase<Wcf_SOAP_Velib.LogService.ILog>, Wcf_SOAP_Velib.LogService.ILog {
        
        public LogClient() {
        }
        
        public LogClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LogClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void recordRequest(System.DateTime date, string method, bool dataInCache) {
            base.Channel.recordRequest(date, method, dataInCache);
        }
        
        public System.Threading.Tasks.Task recordRequestAsync(System.DateTime date, string method, bool dataInCache) {
            return base.Channel.recordRequestAsync(date, method, dataInCache);
        }
        
        public string getAllLogs() {
            return base.Channel.getAllLogs();
        }
        
        public System.Threading.Tasks.Task<string> getAllLogsAsync() {
            return base.Channel.getAllLogsAsync();
        }
        
        public int getClientResquests(System.DateTime begin, System.DateTime end) {
            return base.Channel.getClientResquests(begin, end);
        }
        
        public System.Threading.Tasks.Task<int> getClientResquestsAsync(System.DateTime begin, System.DateTime end) {
            return base.Channel.getClientResquestsAsync(begin, end);
        }
    }
}