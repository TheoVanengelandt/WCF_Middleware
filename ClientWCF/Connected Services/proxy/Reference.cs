﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWCF.proxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="STC_MSG", Namespace="http://schemas.datacontract.org/2004/07/Middleware")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial struct STC_MSG : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string app_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string app_tokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string app_versionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] dataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string op_infoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string op_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool op_statutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string user_loginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string user_pswField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string user_tokenField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string app_name {
            get {
                return this.app_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.app_nameField, value) != true)) {
                    this.app_nameField = value;
                    this.RaisePropertyChanged("app_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string app_token {
            get {
                return this.app_tokenField;
            }
            set {
                if ((object.ReferenceEquals(this.app_tokenField, value) != true)) {
                    this.app_tokenField = value;
                    this.RaisePropertyChanged("app_token");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string app_version {
            get {
                return this.app_versionField;
            }
            set {
                if ((object.ReferenceEquals(this.app_versionField, value) != true)) {
                    this.app_versionField = value;
                    this.RaisePropertyChanged("app_version");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] data {
            get {
                return this.dataField;
            }
            set {
                if ((object.ReferenceEquals(this.dataField, value) != true)) {
                    this.dataField = value;
                    this.RaisePropertyChanged("data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string op_info {
            get {
                return this.op_infoField;
            }
            set {
                if ((object.ReferenceEquals(this.op_infoField, value) != true)) {
                    this.op_infoField = value;
                    this.RaisePropertyChanged("op_info");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string op_name {
            get {
                return this.op_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.op_nameField, value) != true)) {
                    this.op_nameField = value;
                    this.RaisePropertyChanged("op_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool op_statut {
            get {
                return this.op_statutField;
            }
            set {
                if ((this.op_statutField.Equals(value) != true)) {
                    this.op_statutField = value;
                    this.RaisePropertyChanged("op_statut");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string user_login {
            get {
                return this.user_loginField;
            }
            set {
                if ((object.ReferenceEquals(this.user_loginField, value) != true)) {
                    this.user_loginField = value;
                    this.RaisePropertyChanged("user_login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string user_psw {
            get {
                return this.user_pswField;
            }
            set {
                if ((object.ReferenceEquals(this.user_pswField, value) != true)) {
                    this.user_pswField = value;
                    this.RaisePropertyChanged("user_psw");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string user_token {
            get {
                return this.user_tokenField;
            }
            set {
                if ((object.ReferenceEquals(this.user_tokenField, value) != true)) {
                    this.user_tokenField = value;
                    this.RaisePropertyChanged("user_token");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="proxy.IAuth")]
    public interface IAuth {
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IAuth/Login", ReplyAction="http://tempuri.org/IAuth/LoginResponse")]
        ClientWCF.proxy.STC_MSG Login(ClientWCF.proxy.STC_MSG msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthChannel : ClientWCF.proxy.IAuth, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthClient : System.ServiceModel.ClientBase<ClientWCF.proxy.IAuth>, ClientWCF.proxy.IAuth {
        
        public AuthClient() {
        }
        
        public AuthClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClientWCF.proxy.STC_MSG Login(ClientWCF.proxy.STC_MSG msg) {
            return base.Channel.Login(msg);
        }
    }
}
