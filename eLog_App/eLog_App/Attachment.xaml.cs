using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System.IO;
using Plugin.DownloadManager;
using System.IO.Compression;
using Dropbox.Api;

namespace eLog_App
{
    public partial class Attachment : ContentPage
    {
        private string Url;
        private readonly HttpClient _client = new HttpClient();
        private string uploadUrl;
        private string downloadUrl;
        private String logId;
        private List<String> fileNameList;
        private List<String> fileIdList;
        //private List<String> checkedFileCount;
        private String checkedFileName;
        private String checkedFileId;


        public Attachment(String logId)
        {
            InitializeComponent();
            this.logId = logId;
        }

        public void uploadFile(object sender, EventArgs e)
        {
            uploadFileAction();
        }

        protected override async void OnAppearing()
        {
            Url = "http://192.168.1.111:8081/etm_log/api/project/log/" + logId + "/attachment";
            AttachmentList.Children.Clear();
            String content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            AttachmentPost posts = JsonConvert.DeserializeObject<AttachmentPost>(content); //Deserializes or converts JSON String into a collection of Post
            for (int i=0; i<posts.returnValue.Count; i++) {
                CheckBox CheckBox = new CheckBox {
                    Text = posts.returnValue[i].filename,
                    Value = posts.returnValue[i].attachmentId,
                };
                CheckBox.CheckedChanged += CheckBox_CheckedChanged;
                AttachmentList.Children.Add(CheckBox);
            };

            fileIdList = new List<String>();
            fileNameList = new List<String>();

            base.OnAppearing();
        }

        public void CheckBox_CheckedChanged(object sender, bool e)
        {

            if (e)
            {
                CheckBox c = (CheckBox)sender;
                checkedFileName = c.Text;
                checkedFileId = c.Value;
                fileIdList.Add(c.Value);
                fileNameList.Add(c.Text);
            }
           else
           {
                CheckBox c = (CheckBox)sender;
                fileIdList.RemoveAt(fileIdList.IndexOf(c.Value));
                fileNameList.RemoveAt(fileNameList.IndexOf(c.Text));
            }
        }        



        public async void uploadFileAction() {
            try
            {
                FileData filedata = await CrossFilePicker.Current.PickFile();
                var upFileBytes = File.ReadAllBytes(filedata.FilePath);

                MultipartFormDataContent content = new MultipartFormDataContent();
                ByteArrayContent baContent = new ByteArrayContent(upFileBytes);
                StringContent studentIdContent = new StringContent(filedata.FileName);
                content.Add(baContent, "file", filedata.FileName);
                String strContent = await content.ReadAsStringAsync();
                content.Add(studentIdContent, "file");

                uploadUrl = "http://192.168.1.111:8081/etm_log/api/project/log/" + logId + "/attachment";
                var response = await _client.PostAsync(uploadUrl, content);

                if (response.IsSuccessStatusCode == true)
                {
                    DisplayAlert("Update Success", "Update Success!", "OK");
                }
                else
                {
                    DisplayAlert("Update Fail", "Update Fail!", "OK");
                }

                base.OnAppearing();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "ok");
            }
        }

        public void downloadFile(object sender, EventArgs e) {
            downloadFileAction();
        }

        public async void downloadFileAction() {

            if (fileIdList.Count == 1) {
                try
                {
                    downloadUrl = "http://192.168.1.111:8081/etm_log/api/project/log/" + logId + "/attachment/" + 
                        checkedFileId + "/" + checkedFileName;

                    var downloadManager = CrossDownloadManager.Current;
                    var file = downloadManager.CreateDownloadFile(downloadUrl);
                             
                    downloadManager.Start(file);
                    DisplayAlert("Download Success", "Download Success!", "OK");
                }
                catch(Exception e) {
                    DisplayAlert("Download Fail", "Download Fail!", "OK");
                }
            }
            else if(fileIdList.Count > 1) {
                DisplayAlert("Download Fail", "Cannot choose more than 1 file.", "OK");
            }

        }

    }
}
