using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Security;

namespace kojan.SmartDownloader
{
    public interface IItem
    {
        string Url { get; set; }
        string FileName { get; set; }

        int Id { get; set; }

        int GetId();

        void SetId();


    }
}