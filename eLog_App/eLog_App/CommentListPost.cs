using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace eLog_App
{
    public class CommentListPost : INotifyPropertyChanged
    {

        public int Id { get; set; }
        private string _codeUserIssued;
        private string _title;
        private string _remark;

        [JsonProperty("codeUserIssued")] //This maps the element title of your web service to your model
        public string codeUserIssued
        {
            get => _codeUserIssued;
            set
            {
                _codeUserIssued = value;
                //OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("title")] //This maps the element title of your web service to your model
        public string title
        {
            get => _title;
            set
            {
                _title = value;
                //OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("remark")] //This maps the element title of your web service to your model
        public string remark
        {
            get => _remark;
            set
            {
                _remark = value;
                //OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

