using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using kojan.SmartDownloader;

namespace SmartDownloaderSample
{
    [Activity(Label = "SmartDownloaderSample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        private SmartDownloader smartDownloader;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Init();
            InitUi();
        }

        private void Init()
        {
            smartDownloader = new SmartDownloader();
            smartDownloader.AllDownloadsCompleted += AlertAllFinished;
        }

        private void InitUi()
        {
            // Get our button from the layout resource,
            // and attach an event to it
            var startDownload = FindViewById<Button>(Resource.Id.StartDownloadBtn);

            startDownload.Click += delegate
            {
                smartDownloader.StartDownloading();
            };

            // Get our button from the layout resource,
            // and attach an event to it
            var addExampleFiles = FindViewById<Button>(Resource.Id.AddExmapleFilesBtn);

            addExampleFiles.Click += (sender, args) =>
            {
                CreateDownloadListExmaple();
            };

        }

        private void AlertAllFinished()
        {
            Toast.MakeText(ApplicationContext, "All Filed downloaded", ToastLength.Long).Show();
        }


        private void CreateDownloadListExmaple()
        {
            var item = new Item
            {
                Url = "http://mirror.internode.on.net/pub/test/1meg.test",
                FileName = "file1.test",
                Id = 1
            };

            smartDownloader.AddFileToQueue(item);

            item = new Item
            {
                Url = "http://mirror.internode.on.net/pub/test/5meg.test1",
                FileName = "file2.test",
                Id = 2
            };

            smartDownloader.AddFileToQueue(item);
          

        }



    }
}

