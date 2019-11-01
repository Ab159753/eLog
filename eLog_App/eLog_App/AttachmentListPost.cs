using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace eLog_App
{
    public class AttachmentListPost : INotifyPropertyChanged
    {

        public int Id { get; set; }
        private string _filename;
        private string _attachmentId

        ;[JsonProperty("filename")] //This maps the element title of your web service to your model
        public string filename
        {
            get => _filename;
            set
            {
                _filename = value;
                //OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("attachmentId")] //This maps the element title of your web service to your model
        public string attachmentId
        {
            get => _attachmentId;
            set
            {
                _attachmentId = value;
                //OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

