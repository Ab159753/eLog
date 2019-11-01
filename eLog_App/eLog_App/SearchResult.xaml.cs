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
    public partial class SearchResult : ContentPage
    {

        private String logNo;
        private string Url; //= "http://corp.nmt.com.hk/etm_log/api/project/log/102034"; //http://jsonplaceholder.typicode.com/posts 
        //http://corp.nmt.com.hk/etm_log/api/project/log/102034 This url is a free public api intended for demos
        private readonly HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)
        //private ObservableCollection<Post> _posts; //Refreshing the state of the UI in realtime when updating the ListView's Collection
        private Post posts;
        private UserPost userInfo;

        public SearchResult(Dictionary<String, String> searchCriteria, UserPost userInfo)
        {
            InitializeComponent();
            this.logNo = searchCriteria["logNo"];
            this.Url = "http://192.168.1.111:8081/etm_log/api/project/log/id/" + logNo;
            this.userInfo = userInfo;
            //listResultView.ItemsSource = new List<String> { "1", "2","3","4","5", "2","3","4","5", "2", "3", "4", "5", "2","3","4","5" };

        }

        public void LogResult_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (posts.LogId != null)
            {
                Navigation.PushAsync(new ResultDetail(posts, userInfo));
            }
        }

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            //List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(content); //Deserializes or converts JSON String into a collection of Post
            posts = JsonConvert.DeserializeObject<Post>(content);
            //_posts = new ObservableCollection<Post>(posts); //Converting the List to ObservalbleCollection of Post
            List<Post> postList = new List<Post>();
            postList.Add(posts);
            listResultView.ItemsSource = postList; //Assigning the ObservableCollection to MyListView in the XAML of this file
            base.OnAppearing();
        }
    }
}
