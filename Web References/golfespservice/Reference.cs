﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
// 
#pragma warning disable 1591

namespace ESPmanager.golfespservice {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="gespwsSoap", Namespace="http://tempuri.org/GolfEspWS/")]
    public partial class gespws : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCoursesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPdaDataInOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRoundsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetTeesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUnprintedRoundsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public gespws() {
            this.Url = global::ESPmanager.Properties.Settings.Default.ESPmanager_golfespservice_gespws;
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
        public event GetCoursesCompletedEventHandler GetCoursesCompleted;
        
        /// <remarks/>
        public event GetPdaDataInCompletedEventHandler GetPdaDataInCompleted;
        
        /// <remarks/>
        public event GetRoundsCompletedEventHandler GetRoundsCompleted;
        
        /// <remarks/>
        public event GetTeesCompletedEventHandler GetTeesCompleted;
        
        /// <remarks/>
        public event GetUnprintedRoundsCompletedEventHandler GetUnprintedRoundsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GolfEspWS/GetCourses", RequestNamespace="http://tempuri.org/GolfEspWS/", ResponseNamespace="http://tempuri.org/GolfEspWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetCourses() {
            object[] results = this.Invoke("GetCourses", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetCoursesAsync() {
            this.GetCoursesAsync(null);
        }
        
        /// <remarks/>
        public void GetCoursesAsync(object userState) {
            if ((this.GetCoursesOperationCompleted == null)) {
                this.GetCoursesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCoursesOperationCompleted);
            }
            this.InvokeAsync("GetCourses", new object[0], this.GetCoursesOperationCompleted, userState);
        }
        
        private void OnGetCoursesOperationCompleted(object arg) {
            if ((this.GetCoursesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCoursesCompleted(this, new GetCoursesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GolfEspWS/GetPdaDataIn", RequestNamespace="http://tempuri.org/GolfEspWS/", ResponseNamespace="http://tempuri.org/GolfEspWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetPdaDataIn() {
            object[] results = this.Invoke("GetPdaDataIn", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetPdaDataInAsync() {
            this.GetPdaDataInAsync(null);
        }
        
        /// <remarks/>
        public void GetPdaDataInAsync(object userState) {
            if ((this.GetPdaDataInOperationCompleted == null)) {
                this.GetPdaDataInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPdaDataInOperationCompleted);
            }
            this.InvokeAsync("GetPdaDataIn", new object[0], this.GetPdaDataInOperationCompleted, userState);
        }
        
        private void OnGetPdaDataInOperationCompleted(object arg) {
            if ((this.GetPdaDataInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPdaDataInCompleted(this, new GetPdaDataInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GolfEspWS/GetRounds", RequestNamespace="http://tempuri.org/GolfEspWS/", ResponseNamespace="http://tempuri.org/GolfEspWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetRounds() {
            object[] results = this.Invoke("GetRounds", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetRoundsAsync() {
            this.GetRoundsAsync(null);
        }
        
        /// <remarks/>
        public void GetRoundsAsync(object userState) {
            if ((this.GetRoundsOperationCompleted == null)) {
                this.GetRoundsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRoundsOperationCompleted);
            }
            this.InvokeAsync("GetRounds", new object[0], this.GetRoundsOperationCompleted, userState);
        }
        
        private void OnGetRoundsOperationCompleted(object arg) {
            if ((this.GetRoundsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRoundsCompleted(this, new GetRoundsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GolfEspWS/GetTees", RequestNamespace="http://tempuri.org/GolfEspWS/", ResponseNamespace="http://tempuri.org/GolfEspWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetTees() {
            object[] results = this.Invoke("GetTees", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetTeesAsync() {
            this.GetTeesAsync(null);
        }
        
        /// <remarks/>
        public void GetTeesAsync(object userState) {
            if ((this.GetTeesOperationCompleted == null)) {
                this.GetTeesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTeesOperationCompleted);
            }
            this.InvokeAsync("GetTees", new object[0], this.GetTeesOperationCompleted, userState);
        }
        
        private void OnGetTeesOperationCompleted(object arg) {
            if ((this.GetTeesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTeesCompleted(this, new GetTeesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GolfEspWS/GetUnprintedRounds", RequestNamespace="http://tempuri.org/GolfEspWS/", ResponseNamespace="http://tempuri.org/GolfEspWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUnprintedRounds() {
            object[] results = this.Invoke("GetUnprintedRounds", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetUnprintedRoundsAsync() {
            this.GetUnprintedRoundsAsync(null);
        }
        
        /// <remarks/>
        public void GetUnprintedRoundsAsync(object userState) {
            if ((this.GetUnprintedRoundsOperationCompleted == null)) {
                this.GetUnprintedRoundsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUnprintedRoundsOperationCompleted);
            }
            this.InvokeAsync("GetUnprintedRounds", new object[0], this.GetUnprintedRoundsOperationCompleted, userState);
        }
        
        private void OnGetUnprintedRoundsOperationCompleted(object arg) {
            if ((this.GetUnprintedRoundsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUnprintedRoundsCompleted(this, new GetUnprintedRoundsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetCoursesCompletedEventHandler(object sender, GetCoursesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCoursesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCoursesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetPdaDataInCompletedEventHandler(object sender, GetPdaDataInCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPdaDataInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPdaDataInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetRoundsCompletedEventHandler(object sender, GetRoundsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRoundsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRoundsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetTeesCompletedEventHandler(object sender, GetTeesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTeesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTeesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetUnprintedRoundsCompletedEventHandler(object sender, GetUnprintedRoundsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUnprintedRoundsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUnprintedRoundsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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