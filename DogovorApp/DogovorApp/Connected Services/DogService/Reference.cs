﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DogovorApp.DogService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Dogovor", Namespace="http://schemas.datacontract.org/2004/07/DogService")]
    [System.SerializableAttribute()]
    public partial class Dogovor : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ACTUALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DOG_DATEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DOG_NOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LAST_UPDATEField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ACTUAL {
            get {
                return this.ACTUALField;
            }
            set {
                if ((this.ACTUALField.Equals(value) != true)) {
                    this.ACTUALField = value;
                    this.RaisePropertyChanged("ACTUAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DOG_DATE {
            get {
                return this.DOG_DATEField;
            }
            set {
                if ((this.DOG_DATEField.Equals(value) != true)) {
                    this.DOG_DATEField = value;
                    this.RaisePropertyChanged("DOG_DATE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DOG_NO {
            get {
                return this.DOG_NOField;
            }
            set {
                if ((object.ReferenceEquals(this.DOG_NOField, value) != true)) {
                    this.DOG_NOField = value;
                    this.RaisePropertyChanged("DOG_NO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LAST_UPDATE {
            get {
                return this.LAST_UPDATEField;
            }
            set {
                if ((this.LAST_UPDATEField.Equals(value) != true)) {
                    this.LAST_UPDATEField = value;
                    this.RaisePropertyChanged("LAST_UPDATE");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DogService.IDogService")]
    public interface IDogService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDogService/CheckActualDate", ReplyAction="http://tempuri.org/IDogService/CheckActualDateResponse")]
        void CheckActualDate(System.DateTime ActualDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDogService/CheckActualDate", ReplyAction="http://tempuri.org/IDogService/CheckActualDateResponse")]
        System.Threading.Tasks.Task CheckActualDateAsync(System.DateTime ActualDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDogService/UpdateDog", ReplyAction="http://tempuri.org/IDogService/UpdateDogResponse")]
        void UpdateDog(DogovorApp.DogService.Dogovor dog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDogService/UpdateDog", ReplyAction="http://tempuri.org/IDogService/UpdateDogResponse")]
        System.Threading.Tasks.Task UpdateDogAsync(DogovorApp.DogService.Dogovor dog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDogService/FillDataTable", ReplyAction="http://tempuri.org/IDogService/FillDataTableResponse")]
        DogovorApp.DogService.Dogovor[] FillDataTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDogService/FillDataTable", ReplyAction="http://tempuri.org/IDogService/FillDataTableResponse")]
        System.Threading.Tasks.Task<DogovorApp.DogService.Dogovor[]> FillDataTableAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDogServiceChannel : DogovorApp.DogService.IDogService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DogServiceClient : System.ServiceModel.ClientBase<DogovorApp.DogService.IDogService>, DogovorApp.DogService.IDogService {
        
        public DogServiceClient() {
        }
        
        public DogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CheckActualDate(System.DateTime ActualDate) {
            base.Channel.CheckActualDate(ActualDate);
        }
        
        public System.Threading.Tasks.Task CheckActualDateAsync(System.DateTime ActualDate) {
            return base.Channel.CheckActualDateAsync(ActualDate);
        }
        
        public void UpdateDog(DogovorApp.DogService.Dogovor dog) {
            base.Channel.UpdateDog(dog);
        }
        
        public System.Threading.Tasks.Task UpdateDogAsync(DogovorApp.DogService.Dogovor dog) {
            return base.Channel.UpdateDogAsync(dog);
        }
        
        public DogovorApp.DogService.Dogovor[] FillDataTable() {
            return base.Channel.FillDataTable();
        }
        
        public System.Threading.Tasks.Task<DogovorApp.DogService.Dogovor[]> FillDataTableAsync() {
            return base.Channel.FillDataTableAsync();
        }
    }
}