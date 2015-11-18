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

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            Init();
        }

        private void Init()
        {
            smartDownloader = new SmartDownloader();
            smartDownloader.AllDownloadsCompleted += () => Toast.MakeText(ApplicationContext, "All Filed downloaded", ToastLength.Long);


            smartDownloader.StartDownloading();
        }






    }
}

