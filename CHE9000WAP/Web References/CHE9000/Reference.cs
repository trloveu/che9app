﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18051
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18051 版自动生成。
// 
#pragma warning disable 1591

namespace CHE9000WAP.CHE9000 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CHE9000Soap", Namespace="http://tempuri.org/")]
    public partial class CHE9000 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ServerDBQueryOneOperationCompleted;
        
        private System.Threading.SendOrPostCallback ServerDBQueryOperationCompleted;
        
        private System.Threading.SendOrPostCallback ServerDBExecOperationCompleted;
        
        private System.Threading.SendOrPostCallback ServerPICSaveOperationCompleted;
        
        private System.Threading.SendOrPostCallback ServerPICReadByIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback ServerPICReadByTypeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CHE9000() {
            this.Url = "http://120.25.156.238/CHE9000SER/CHE9000.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ServerDBQueryOneCompletedEventHandler ServerDBQueryOneCompleted;
        
        /// <remarks/>
        public event ServerDBQueryCompletedEventHandler ServerDBQueryCompleted;
        
        /// <remarks/>
        public event ServerDBExecCompletedEventHandler ServerDBExecCompleted;
        
        /// <remarks/>
        public event ServerPICSaveCompletedEventHandler ServerPICSaveCompleted;
        
        /// <remarks/>
        public event ServerPICReadByIDCompletedEventHandler ServerPICReadByIDCompleted;
        
        /// <remarks/>
        public event ServerPICReadByTypeCompletedEventHandler ServerPICReadByTypeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ServerDBQueryOne", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerDBQueryOne(string strProcName, System.Data.DataSet dsIN) {
            object[] results = this.Invoke("ServerDBQueryOne", new object[] {
                        strProcName,
                        dsIN});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ServerDBQueryOneAsync(string strProcName, System.Data.DataSet dsIN) {
            this.ServerDBQueryOneAsync(strProcName, dsIN, null);
        }
        
        /// <remarks/>
        public void ServerDBQueryOneAsync(string strProcName, System.Data.DataSet dsIN, object userState) {
            if ((this.ServerDBQueryOneOperationCompleted == null)) {
                this.ServerDBQueryOneOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerDBQueryOneOperationCompleted);
            }
            this.InvokeAsync("ServerDBQueryOne", new object[] {
                        strProcName,
                        dsIN}, this.ServerDBQueryOneOperationCompleted, userState);
        }
        
        private void OnServerDBQueryOneOperationCompleted(object arg) {
            if ((this.ServerDBQueryOneCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerDBQueryOneCompleted(this, new ServerDBQueryOneCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ServerDBQuery", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet ServerDBQuery(string strProcName, System.Data.DataSet dsIN) {
            object[] results = this.Invoke("ServerDBQuery", new object[] {
                        strProcName,
                        dsIN});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void ServerDBQueryAsync(string strProcName, System.Data.DataSet dsIN) {
            this.ServerDBQueryAsync(strProcName, dsIN, null);
        }
        
        /// <remarks/>
        public void ServerDBQueryAsync(string strProcName, System.Data.DataSet dsIN, object userState) {
            if ((this.ServerDBQueryOperationCompleted == null)) {
                this.ServerDBQueryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerDBQueryOperationCompleted);
            }
            this.InvokeAsync("ServerDBQuery", new object[] {
                        strProcName,
                        dsIN}, this.ServerDBQueryOperationCompleted, userState);
        }
        
        private void OnServerDBQueryOperationCompleted(object arg) {
            if ((this.ServerDBQueryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerDBQueryCompleted(this, new ServerDBQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ServerDBExec", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerDBExec(string strProcName, System.Data.DataSet dsIN) {
            object[] results = this.Invoke("ServerDBExec", new object[] {
                        strProcName,
                        dsIN});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ServerDBExecAsync(string strProcName, System.Data.DataSet dsIN) {
            this.ServerDBExecAsync(strProcName, dsIN, null);
        }
        
        /// <remarks/>
        public void ServerDBExecAsync(string strProcName, System.Data.DataSet dsIN, object userState) {
            if ((this.ServerDBExecOperationCompleted == null)) {
                this.ServerDBExecOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerDBExecOperationCompleted);
            }
            this.InvokeAsync("ServerDBExec", new object[] {
                        strProcName,
                        dsIN}, this.ServerDBExecOperationCompleted, userState);
        }
        
        private void OnServerDBExecOperationCompleted(object arg) {
            if ((this.ServerDBExecCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerDBExecCompleted(this, new ServerDBExecCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ServerPICSave", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerPICSave(int iBillID, int iType, string strFileName, string strFILEByte) {
            object[] results = this.Invoke("ServerPICSave", new object[] {
                        iBillID,
                        iType,
                        strFileName,
                        strFILEByte});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ServerPICSaveAsync(int iBillID, int iType, string strFileName, string strFILEByte) {
            this.ServerPICSaveAsync(iBillID, iType, strFileName, strFILEByte, null);
        }
        
        /// <remarks/>
        public void ServerPICSaveAsync(int iBillID, int iType, string strFileName, string strFILEByte, object userState) {
            if ((this.ServerPICSaveOperationCompleted == null)) {
                this.ServerPICSaveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerPICSaveOperationCompleted);
            }
            this.InvokeAsync("ServerPICSave", new object[] {
                        iBillID,
                        iType,
                        strFileName,
                        strFILEByte}, this.ServerPICSaveOperationCompleted, userState);
        }
        
        private void OnServerPICSaveOperationCompleted(object arg) {
            if ((this.ServerPICSaveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerPICSaveCompleted(this, new ServerPICSaveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ServerPICReadByID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerPICReadByID(int iFileID) {
            object[] results = this.Invoke("ServerPICReadByID", new object[] {
                        iFileID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ServerPICReadByIDAsync(int iFileID) {
            this.ServerPICReadByIDAsync(iFileID, null);
        }
        
        /// <remarks/>
        public void ServerPICReadByIDAsync(int iFileID, object userState) {
            if ((this.ServerPICReadByIDOperationCompleted == null)) {
                this.ServerPICReadByIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerPICReadByIDOperationCompleted);
            }
            this.InvokeAsync("ServerPICReadByID", new object[] {
                        iFileID}, this.ServerPICReadByIDOperationCompleted, userState);
        }
        
        private void OnServerPICReadByIDOperationCompleted(object arg) {
            if ((this.ServerPICReadByIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerPICReadByIDCompleted(this, new ServerPICReadByIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ServerPICReadByType", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerPICReadByType(int iBillID, int iType) {
            object[] results = this.Invoke("ServerPICReadByType", new object[] {
                        iBillID,
                        iType});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ServerPICReadByTypeAsync(int iBillID, int iType) {
            this.ServerPICReadByTypeAsync(iBillID, iType, null);
        }
        
        /// <remarks/>
        public void ServerPICReadByTypeAsync(int iBillID, int iType, object userState) {
            if ((this.ServerPICReadByTypeOperationCompleted == null)) {
                this.ServerPICReadByTypeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerPICReadByTypeOperationCompleted);
            }
            this.InvokeAsync("ServerPICReadByType", new object[] {
                        iBillID,
                        iType}, this.ServerPICReadByTypeOperationCompleted, userState);
        }
        
        private void OnServerPICReadByTypeOperationCompleted(object arg) {
            if ((this.ServerPICReadByTypeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerPICReadByTypeCompleted(this, new ServerPICReadByTypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ServerDBQueryOneCompletedEventHandler(object sender, ServerDBQueryOneCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerDBQueryOneCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerDBQueryOneCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ServerDBQueryCompletedEventHandler(object sender, ServerDBQueryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerDBQueryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerDBQueryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ServerDBExecCompletedEventHandler(object sender, ServerDBExecCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerDBExecCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerDBExecCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ServerPICSaveCompletedEventHandler(object sender, ServerPICSaveCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerPICSaveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerPICSaveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ServerPICReadByIDCompletedEventHandler(object sender, ServerPICReadByIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerPICReadByIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerPICReadByIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ServerPICReadByTypeCompletedEventHandler(object sender, ServerPICReadByTypeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerPICReadByTypeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerPICReadByTypeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591