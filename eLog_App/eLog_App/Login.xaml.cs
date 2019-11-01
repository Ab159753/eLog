using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace eLog_App
{
    public partial class Login : ContentPage
    {

        private string Url; 
        private readonly HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)

        public Login()
        {
            InitializeComponent();
        }

        public async void btn_Login (Object sender, System.EventArgs e) {
            Url = "http://192.168.1.111:8081/etm_log/api/project/log/login/username/"+ username.Text + "/password/" + password.Text;
            string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            //List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(content); //Deserializes or converts JSON String into a collection of Post
            UserPost posts = JsonConvert.DeserializeObject<UserPost>(content);

            if (posts.CodeUser != null) {
                Navigation.PushAsync(new Search(posts));
            }else {
                DisplayAlert("Login Fail","Username or Paswword is invalid.","OK");
            }
        }

    }
}
