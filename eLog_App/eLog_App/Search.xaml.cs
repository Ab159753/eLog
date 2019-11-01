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
    public partial class Search : ContentPage
    {
        private UserPost userInfo;
        public Search(UserPost userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        public void btn_Search(Object sender, System.EventArgs e)
        {
            //List<String> searchCriteria = new List<String>();
            Dictionary<String, String> searchCriteria = new Dictionary<string, string>();
            searchCriteria.Add("logNo",logNo.Text);
            Navigation.PushAsync(new SearchResult(searchCriteria, userInfo));

        }


    }
}
