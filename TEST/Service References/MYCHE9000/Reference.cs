﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18051
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TEST.MYCHE9000 {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MYCHE9000.CHE9000Soap")]
    public interface CHE9000Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerDBQueryOne", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ServerDBQueryOne(string strProcName, System.Data.DataSet dsIN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerDBQuery", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ServerDBQuery(string strProcName, System.Data.DataSet dsIN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerDBExec", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ServerDBExec(string strProcName, System.Data.DataSet dsIN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerPICSave", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ServerPICSave(int iBillID, int iType, string strFileName, string strFILEByte);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerPICReadByID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ServerPICReadByID(int iFileID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerPICReadByType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ServerPICReadByType(int iBillID, int iType);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CHE9000SoapChannel : TEST.MYCHE9000.CHE9000Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CHE9000SoapClient : System.ServiceModel.ClientBase<TEST.MYCHE9000.CHE9000Soap>, TEST.MYCHE9000.CHE9000Soap {
        
        public CHE9000SoapClient() {
        }
        
        public CHE9000SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CHE9000SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CHE9000SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CHE9000SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ServerDBQueryOne(string strProcName, System.Data.DataSet dsIN) {
            return base.Channel.ServerDBQueryOne(strProcName, dsIN);
        }
        
        public System.Data.DataSet ServerDBQuery(string strProcName, System.Data.DataSet dsIN) {
            return base.Channel.ServerDBQuery(strProcName, dsIN);
        }
        
        public string ServerDBExec(string strProcName, System.Data.DataSet dsIN) {
            return base.Channel.ServerDBExec(strProcName, dsIN);
        }
        
        public string ServerPICSave(int iBillID, int iType, string strFileName, string strFILEByte) {
            return base.Channel.ServerPICSave(iBillID, iType, strFileName, strFILEByte);
        }
        
        public string ServerPICReadByID(int iFileID) {
            return base.Channel.ServerPICReadByID(iFileID);
        }
        
        public string ServerPICReadByType(int iBillID, int iType) {
            return base.Channel.ServerPICReadByType(iBillID, iType);
        }
    }
}