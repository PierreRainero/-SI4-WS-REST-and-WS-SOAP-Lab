﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_Console_Monitoring.LogService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LogService.ILog")]
    public interface ILog {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/recordRequest", ReplyAction="http://tempuri.org/ILog/recordRequestResponse")]
        void recordRequest(System.DateTime date, string method, bool dataInCache, System.TimeSpan delay);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/recordRequest", ReplyAction="http://tempuri.org/ILog/recordRequestResponse")]
        System.Threading.Tasks.Task recordRequestAsync(System.DateTime date, string method, bool dataInCache, System.TimeSpan delay);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getAllLogs", ReplyAction="http://tempuri.org/ILog/getAllLogsResponse")]
        string getAllLogs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getAllLogs", ReplyAction="http://tempuri.org/ILog/getAllLogsResponse")]
        System.Threading.Tasks.Task<string> getAllLogsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getClientResquests", ReplyAction="http://tempuri.org/ILog/getClientResquestsResponse")]
        int getClientResquests(System.DateTime begin, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getClientResquests", ReplyAction="http://tempuri.org/ILog/getClientResquestsResponse")]
        System.Threading.Tasks.Task<int> getClientResquestsAsync(System.DateTime begin, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getAVGDelayOf", ReplyAction="http://tempuri.org/ILog/getAVGDelayOfResponse")]
        string getAVGDelayOf(string method);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILog/getAVGDelayOf", ReplyAction="http://tempuri.org/ILog/getAVGDelayOfResponse")]
        System.Threading.Tasks.Task<string> getAVGDelayOfAsync(string method);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILogChannel : Client_Console_Monitoring.LogService.ILog, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogClient : System.ServiceModel.ClientBase<Client_Console_Monitoring.LogService.ILog>, Client_Console_Monitoring.LogService.ILog {
        
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
        
        public void recordRequest(System.DateTime date, string method, bool dataInCache, System.TimeSpan delay) {
            base.Channel.recordRequest(date, method, dataInCache, delay);
        }
        
        public System.Threading.Tasks.Task recordRequestAsync(System.DateTime date, string method, bool dataInCache, System.TimeSpan delay) {
            return base.Channel.recordRequestAsync(date, method, dataInCache, delay);
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
        
        public string getAVGDelayOf(string method) {
            return base.Channel.getAVGDelayOf(method);
        }
        
        public System.Threading.Tasks.Task<string> getAVGDelayOfAsync(string method) {
            return base.Channel.getAVGDelayOfAsync(method);
        }
    }
}
