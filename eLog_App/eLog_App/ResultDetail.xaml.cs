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
    public partial class ResultDetail : ContentPage
    {

        private string Url; //http://jsonplaceholder.typicode.com/posts 
        private string updateUrl;
        private readonly HttpClient _client = new HttpClient();
        public SwitchCell CommentSwitch;
        public SwitchCell AttachmentSwitch;
        public SwitchCell CommentSwitchDetail;
        public SwitchCell AttachmentSwitchDetail;
        private Post posts;
        private UserPost userInfo;


        public ResultDetail(Post posts, UserPost userInfo)
        {
            InitializeComponent();
            this.posts = posts;
            this.userInfo = userInfo;
            //resultView.Root.Remove(Details);
            resultViewDetail.IsVisible = false;
            resultView.IsVisible = true;
        }

        public void EditMode_Handle(Object sender, EventArgs e)
        {
            if (EditBtn.Text == "Edit")
            {
                EditBtn.Text = "Save";
                DetailBtn.IsEnabled = false;
                resultViewDetail.IsVisible = true;
                resultView.IsVisible = false;
                LogTitle.IsEnabled = true;
                Priority.IsEnabled = true;
                AssignTo.IsEnabled = true;
                Status.IsEnabled = true;
                ParentLog.IsEnabled = true;
                Organization.IsEnabled = true;
                Project.IsEnabled = true;
                Ver.IsEnabled = true;
                FunctionCode.IsEnabled = true;
                LogType.IsEnabled = true;
                LogEnvironment.IsEnabled = true;
                IncidentType.IsEnabled = true;
                UserRef.IsEnabled = true;
            }
            else
            {
                EditBtn.Text = "Edit";
                DetailBtn.IsEnabled = true;
                resultViewDetail.IsVisible = false;
                resultView.IsVisible = true;
                LogTitle.IsEnabled = false;
                Priority.IsEnabled = false;
                AssignTo.IsEnabled = false;
                Status.IsEnabled = false;
                ParentLog.IsEnabled = false;
                Organization.IsEnabled = false;
                Project.IsEnabled = false;
                Ver.IsEnabled = false;
                FunctionCode.IsEnabled = false;
                LogType.IsEnabled = false;
                LogEnvironment.IsEnabled = false;
                IncidentType.IsEnabled = false;
                UserRef.IsEnabled = false;

                updateLogInfo();
                base.OnAppearing();
            }

        }

        public void detalsShow_Selected (Object sender, Xamarin.Forms.ToggledEventArgs e) {

            if (_DetailBtn.On == true && resultView.IsVisible == true)
            {
                _DetailBtn.On = false;
                DetailBtn.On = true;
                resultViewDetail.IsVisible = true;
                resultView.IsVisible = false;
            } else if (DetailBtn.On == false && resultViewDetail.IsVisible == true) {
                _DetailBtn.On = false;
                DetailBtn.On = true;
                resultViewDetail.IsVisible = false;
                resultView.IsVisible = true;
            };

        }

        public void addComment_Clicked(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Navigation.PushAsync(new CommentPage(posts.LogId));
        }

        public void attachmentManagement_Clicked(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Navigation.PushAsync(new Attachment(posts.LogId));
        }

        protected override async void OnAppearing()
        {
            Url = "http://192.168.1.111:8081/etm_log/api/project/log/" + posts.LogId + "/remark";
            String content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            CommentPost commentPosts = JsonConvert.DeserializeObject<CommentPost>(content); //Deserializes or converts JSON String into a collection of Post
            Comment.Clear();
            Attachment.Clear();
            CommentDetail.Clear();
            AttachmentDetail.Clear();
            for (int i = 0; i < commentPosts.returnValue.Count; i++)
            {
                Comment.Add(new TextCell
                {
                    Text = commentPosts.returnValue[i].title,
                    Detail = commentPosts.returnValue[i].remark
                });
                CommentDetail.Add(new TextCell
                {
                    Text = commentPosts.returnValue[i].title,
                    Detail = commentPosts.returnValue[i].remark
                });
            };
            CommentSwitch = new SwitchCell();
            CommentSwitch.OnChanged += addComment_Clicked;
            CommentSwitch.Text = "Add Comment";
            Comment.Add(CommentSwitch);
            CommentSwitchDetail = new SwitchCell();
            CommentSwitchDetail.OnChanged += addComment_Clicked;
            CommentSwitchDetail.Text = "Add Comment";
            CommentDetail.Add(CommentSwitchDetail);

            AttachmentSwitch = new SwitchCell();
            AttachmentSwitch.OnChanged += attachmentManagement_Clicked;
            AttachmentSwitch.Text = "Attachment Download";
            Attachment.Add(AttachmentSwitch);
            AttachmentSwitchDetail = new SwitchCell();
            AttachmentSwitchDetail.OnChanged += attachmentManagement_Clicked;
            AttachmentSwitchDetail.Text = "Attachment Download";
            AttachmentDetail.Add(AttachmentSwitchDetail);

            _LogNo.Text = posts.LogId;
            LogNo.Text = posts.LogId;

            _LogTitle.Text = posts.Title;
            LogTitle.Text = posts.Title;

            _Priority.Text = posts.codePriority;
            Priority.Text = posts.codePriority;

            _AssignTo.Text = posts.codeUserAction;
            AssignTo.Text = posts.codeUserAction;

            _Status.Text = posts.Status;
            Status.Text = posts.Status;

            ParentLog.Text = posts.parentIdLog;
            Organization.Text = posts.codeOrg;
            Project.Text = posts.codeProject;
            Ver.Text = posts.versionNo;
            FunctionCode.Text = posts.codeFunc;
            IssuedBy.Text = posts.codeUserIssued;
            IssuedDate.Text = posts.issueDate;
            LogType.Text = posts.codeLogType;
            LogEnvironment.Text = posts.codeEnvironment;
            IncidentType.Text = posts.codeIncidentType;
            UserRef.Text = posts.userLogRef;

            base.OnAppearing();
        }

        private async void updateLogInfo() {
            updateUrl = "http://192.168.1.111:8081/etm_log/api/project/log/" + posts.LogId;

            String httpContentString = "{\"timestamp\":1544768606000,\"createdByUser\":\"TEST\",\"createdDatetime\"" +
            	":1544768606000,\"updatedByUser\":\"TEST\"" +
                ",\"updatedDatetime\":1544768606000,\"idLog\":" + 
                posts.LogId + ",\"parentId\":" + ((ParentLog.Text==null)? "null" : ParentLog.Text) +
                 ",\"organization\":\"" + Organization.Text + "\",\"projectCode\":\"" + Project.Text +
                "\",\"version\":\"" + Ver.Text + "\",\"title\":\"" + LogTitle.Text + "\",\"functionCode\":\"" + FunctionCode.Text + 
                "\",\"priority\":\"" +
                Priority.Text + "\",\"logType\":\"" + LogType.Text + "\",\"logEnvironment\":\"" + LogEnvironment.Text + "\",\"incidentType\":\"" +
                IncidentType.Text + "\",\"userRef\":\"" + UserRef.Text + "\",\"assignTo\":\"" + AssignTo.Text + "\",\"assignDate\":" + 
                ((posts.assignDate==null)? "null" : posts.assignDate) +
                ",\"startDate\":" + ((posts.startDate == null) ? "null" : posts.startDate) + ",\"endDate\":" +
                 ((posts.endDate == null) ? "null" : posts.endDate) + ",\"reportedInVer\":\"" + ((posts.currRel == null) ? null : posts.currRel) + 
                "\",\"targetRelease\":\"" + 
                posts.targetRelease + "\",\"codeUserIssued\":\"" + IssuedBy.Text + "\",\"issueDate\":" +
                 ((posts.issueDate == null) ? null : posts.issueDate) + ",\"status\":\"" + 
                Status.Text + "\"}";
            HttpContent httpContent = new StringContent(httpContentString, Encoding.UTF8, "application/json");
            String test = await httpContent.ReadAsStringAsync();
            //DisplayAlert("test", test, "ok");
            var result = await _client.PutAsync(updateUrl, httpContent);

            if (result.IsSuccessStatusCode == true) {
                DisplayAlert("Update Success","Update Success!","OK");
            }
            else {
                DisplayAlert("Update Fail", "Update Fail!", "OK");
            }

            base.OnAppearing();
            //DisplayAlert("test", result.ToString(), "ok");

        }
    }
}
