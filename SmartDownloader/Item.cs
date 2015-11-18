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

namespace kojan.SmartDownloader
{
    public class Item :IItem
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public int Id { get; set; }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId()
        {
            throw new NotImplementedException();
        }
    }
}