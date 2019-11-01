using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Text;

namespace eLog_App
{
    public partial class CommentPage : ContentPage
    {

        private string Url;
        private readonly HttpClient _client = new HttpClient();
        private String logId;

        public CommentPage(String logId)
        {
            InitializeComponent();
            this.logId = logId;        
        }

        public void createRemark(Object sender, System.EventArgs e) {
            addRemark();
            Title.Title = null;
            Title.SelectedValue = null;
            Remark.Text = null;
        }

        public async void addRemark() {
            Url = "http://192.168.1.111:8081/etm_log/api/project/log/"+ logId + "/detail";
            String httpContentString = "{\"title\":\"" + Title.SelectedValue + "\",\"remark\":\"" + Remark.Text 
                + "\",\"logDetailId\":\"test\",\"parentId\":\"test\"}";
            HttpContent httpContent = new StringContent(httpContentString, Encoding.UTF8, "application/json");

            String test = await httpContent.ReadAsStringAsync();
            //DisplayAlert("test", test, "ok");
            var result = await _client.PostAsync(Url, httpContent);

            if (result.IsSuccessStatusCode == true)
            {
                DisplayAlert("Update Success", "Update Success!", "OK");
            }
            else
            {
                DisplayAlert("Update Fail", "Update Fail!", "OK");
            }
            //DisplayAlert("test", result.ToString(), "ok");
        }

    }
}
