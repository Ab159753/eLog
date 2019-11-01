using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace eLog_App
{
    public class UserPost : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _codeSubscriber;
        private string _codeUser;
        private string _username;
        private string _codeCompany;
        private string _employeeType;
        private string _status;
        private string _password;


        [JsonProperty("codeSubscriber")] //This maps the element title of your web service to your model
        public string CodeSubscriber
        {
            get => _codeSubscriber;
            set
            {
                _codeSubscriber = value;
            }
        }

        [JsonProperty("codeUser")] //This maps the element title of your web service to your model
        public string CodeUser
        {
            get => _codeUser;
            set
            {
                _codeUser = value;
            }
        }

        [JsonProperty("username")] //This maps the element title of your web service to your model
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
            }
        }

        [JsonProperty("codeCompany")] //This maps the element title of your web service to your model
        public string CodeCompany
        {
            get => _codeCompany;
            set
            {
                _codeCompany = value;
            }
        }

        [JsonProperty("employeeType")] //This maps the element title of your web service to your model
        public string EmployeeType
        {
            get => _employeeType;
            set
            {
                _employeeType = value;
            }
        }

        [JsonProperty("status")] //This maps the element title of your web service to your model
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
            }
        }

        [JsonProperty("password")] //This maps the element title of your web service to your model
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

