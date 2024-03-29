﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace eLog_App
{
    public class CommentPost : INotifyPropertyChanged
    {

        public int Id { get; set; }

        private List<CommentListPost> _returnValue;

        [JsonProperty("returnValue")]
        public List<CommentListPost> returnValue
        {
            get => _returnValue;
            set
            {
                _returnValue = value;
                //OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}