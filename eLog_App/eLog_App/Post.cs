using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;


namespace eLog_App
{
    public class Post : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _title;
        private string _status;
        private string _codeOrg;
        private string _codeProject;
        private string _versionNo;
        private string _codeFunc;
        private string _codeUserAction;
        private string _codeUserIssued;
        private string _expectedCompletionDate;
        private string _codePriority;
        private string _logId;
        private string _assignDate;
        private string _startDate;
        private string _endDate;
        private string _issueDate;
        private string _idLogRel;
        private string _codeLogType;
        private string _codeIncidentType;
        private string _userLogRef;
        private string _timestamp;
        private string _currRel;
        private string _lastUpdatedBy;
        private string _codeEnvironment;
        private string _parentIdLog;
        private string _refRelNo;

        [JsonProperty("title")] //This maps the element title of your web service to your model
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("status")] //This maps the element title of your web service to your model
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("idLog")] //This maps the element title of your web service to your model
        public string LogId
        {
            get => _logId;
            set
            {
                _logId = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("projectCode")] //This maps the element title of your web service to your model
        public string codeProject
        {
            get => _codeProject;
            set
            {
                _codeProject = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("version")] //This maps the element title of your web service to your model
        public string versionNo
        {
            get => _versionNo;
            set
            {
                _versionNo = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("functionCode")] //This maps the element title of your web service to your model
        public string codeFunc
        {
            get => _codeFunc;
            set
            {
                _codeFunc = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("assignTo")] //This maps the element title of your web service to your model
        public string codeUserAction
        {
            get => _codeUserAction;
            set
            {
                _codeUserAction = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("codeUserIssued")] //This maps the element title of your web service to your model
        public string codeUserIssued
        {
            get => _codeUserIssued;
            set
            {
                _codeUserIssued = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }
        /*
        [JsonProperty("expectedCompletionDate")] //This maps the element title of your web service to your model
        public string expectedCompletionDate
        {
            get => _expectedCompletionDate;
            set
            {
                _expectedCompletionDate = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }*/

        [JsonProperty("priority")] //This maps the element title of your web service to your model
        public string codePriority
        {
            get => _codePriority;
            set
            {
                _codePriority = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("startDate")] //This maps the element title of your web service to your model
        public string startDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("assignDate")] //This maps the element title of your web service to your model
        public string assignDate
        {
            get => _assignDate;
            set
            {
                _assignDate = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("endDate")] //This maps the element title of your web service to your model
        public string endDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("issueDate")] //This maps the element title of your web service to your model
        public string issueDate
        {
            get => _issueDate;
            set
            {
                _issueDate = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("logType")] //This maps the element title of your web service to your model
        public string codeLogType
        {
            get => _codeLogType;
            set
            {
                _codeLogType = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("incidentType")] //This maps the element title of your web service to your model
        public string codeIncidentType
        {
            get => _codeIncidentType;
            set
            {
                _codeIncidentType = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("userRef")] //This maps the element title of your web service to your model
        public string userLogRef
        {
            get => _userLogRef;
            set
            {
                _userLogRef = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("timestamp")] //This maps the element title of your web service to your model
        public string timestamp
        {
            get => _timestamp;
            set
            {
                _timestamp = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("reportedInVer")] //This maps the element title of your web service to your model
        public string currRel
        {
            get => _currRel;
            set
            {
                _currRel = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("updatedDatetime")] //This maps the element title of your web service to your model
        public string lastUpdatedBy
        {
            get => _lastUpdatedBy;
            set
            {
                _lastUpdatedBy = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("logEnvironment")] //This maps the element title of your web service to your model
        public string codeEnvironment
        {
            get => _codeEnvironment;
            set
            {
                _codeEnvironment = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("parentId")] //This maps the element title of your web service to your model
        public string parentIdLog
        {
            get => _parentIdLog;
            set
            {
                _parentIdLog = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("targetRelease")] //This maps the element title of your web service to your model
        public string targetRelease
        {
            get => _refRelNo;
            set
            {
                _refRelNo = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("organization")] //This maps the element title of your web service to your model
        public string codeOrg
        {
            get => _codeOrg;
            set
            {
                _codeOrg = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }



        //This is how you create your OnPropertyChanged() method
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}