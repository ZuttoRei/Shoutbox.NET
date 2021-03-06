﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shoutbox.NET.SSTMonitorService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Status", Namespace="http://schemas.datacontract.org/2004/07/SSTMonitorService")]
    public enum Status : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Online = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Warning = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Offline = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unknown = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SSTMonitorService.ISSTMonitorService")]
    public interface ISSTMonitorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSTMonitorService/GetStatus", ReplyAction="http://tempuri.org/ISSTMonitorService/GetStatusResponse")]
        Shoutbox.NET.SSTMonitorService.Status GetStatus(string Service);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSTMonitorService/GetStatus", ReplyAction="http://tempuri.org/ISSTMonitorService/GetStatusResponse")]
        System.Threading.Tasks.Task<Shoutbox.NET.SSTMonitorService.Status> GetStatusAsync(string Service);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISSTMonitorServiceChannel : Shoutbox.NET.SSTMonitorService.ISSTMonitorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SSTMonitorServiceClient : System.ServiceModel.ClientBase<Shoutbox.NET.SSTMonitorService.ISSTMonitorService>, Shoutbox.NET.SSTMonitorService.ISSTMonitorService {
        
        public SSTMonitorServiceClient() {
        }
        
        public SSTMonitorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SSTMonitorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SSTMonitorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SSTMonitorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Shoutbox.NET.SSTMonitorService.Status GetStatus(string Service) {
            return base.Channel.GetStatus(Service);
        }
        
        public System.Threading.Tasks.Task<Shoutbox.NET.SSTMonitorService.Status> GetStatusAsync(string Service) {
            return base.Channel.GetStatusAsync(Service);
        }
    }
}
