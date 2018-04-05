﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_Console_Velib.VelibSOAP {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibSOAP.IVelibOperations", CallbackContract=typeof(Client_Console_Velib.VelibSOAP.IVelibOperationsCallback))]
    public interface IVelibOperations {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/getCities", ReplyAction="http://tempuri.org/IVelibOperations/getCitiesResponse")]
        string[] getCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/getCities", ReplyAction="http://tempuri.org/IVelibOperations/getCitiesResponse")]
        System.Threading.Tasks.Task<string[]> getCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/getStations", ReplyAction="http://tempuri.org/IVelibOperations/getStationsResponse")]
        string[] getStations(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/getStations", ReplyAction="http://tempuri.org/IVelibOperations/getStationsResponse")]
        System.Threading.Tasks.Task<string[]> getStationsAsync(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/getAvailableBikes", ReplyAction="http://tempuri.org/IVelibOperations/getAvailableBikesResponse")]
        int getAvailableBikes(string city, string station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/getAvailableBikes", ReplyAction="http://tempuri.org/IVelibOperations/getAvailableBikesResponse")]
        System.Threading.Tasks.Task<int> getAvailableBikesAsync(string city, string station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/SubscribeAvailableBikesChanged", ReplyAction="http://tempuri.org/IVelibOperations/SubscribeAvailableBikesChangedResponse")]
        void SubscribeAvailableBikesChanged(string city, string station, int millis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibOperations/SubscribeAvailableBikesChanged", ReplyAction="http://tempuri.org/IVelibOperations/SubscribeAvailableBikesChangedResponse")]
        System.Threading.Tasks.Task SubscribeAvailableBikesChangedAsync(string city, string station, int millis);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibOperationsCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IVelibOperations/ValueChanged")]
        void ValueChanged(string city, string station, int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibOperationsChannel : Client_Console_Velib.VelibSOAP.IVelibOperations, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibOperationsClient : System.ServiceModel.DuplexClientBase<Client_Console_Velib.VelibSOAP.IVelibOperations>, Client_Console_Velib.VelibSOAP.IVelibOperations {
        
        public VelibOperationsClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public VelibOperationsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public VelibOperationsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public VelibOperationsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public VelibOperationsClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string[] getCities() {
            return base.Channel.getCities();
        }
        
        public System.Threading.Tasks.Task<string[]> getCitiesAsync() {
            return base.Channel.getCitiesAsync();
        }
        
        public string[] getStations(string city) {
            return base.Channel.getStations(city);
        }
        
        public System.Threading.Tasks.Task<string[]> getStationsAsync(string city) {
            return base.Channel.getStationsAsync(city);
        }
        
        public int getAvailableBikes(string city, string station) {
            return base.Channel.getAvailableBikes(city, station);
        }
        
        public System.Threading.Tasks.Task<int> getAvailableBikesAsync(string city, string station) {
            return base.Channel.getAvailableBikesAsync(city, station);
        }
        
        public void SubscribeAvailableBikesChanged(string city, string station, int millis) {
            base.Channel.SubscribeAvailableBikesChanged(city, station, millis);
        }
        
        public System.Threading.Tasks.Task SubscribeAvailableBikesChangedAsync(string city, string station, int millis) {
            return base.Channel.SubscribeAvailableBikesChangedAsync(city, station, millis);
        }
    }
}
