using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Android.Widget;

namespace kojan.SmartDownloader
{
    public delegate void MyVoidDelegate();   // delegate declaration

    public class SmartDownloader
    {
        public event MyVoidDelegate AllDownloadsCompleted;

        private List<IItem> _itemsToDowload; 
        

        public void AddFileToQueue(IItem item)
        {
            var itemsList = GetItemsInQueue();

            itemsList.Add(item);
        }

        /// <summary>
        /// start downloading files 
        /// </summary>
        public void StartDownloading()
        {
            

            var itemsList = GetItemsInQueue();

            if (CheckIfAllFinished()) // make sure we are not done,maybe no items in list
                return;

            var directory = GetSaveToDirectory();

            itemsList.ForEach(item =>
            {
                var webClient = new WebClient();

                webClient.DownloadFileCompleted += OnDownloadFileCompleted(item.Id);

                var filePath = directory + "/" + item.FileName;

                webClient.DownloadFileAsync(new Uri(item.Url), filePath);
            });

            

        }

        private string GetSaveToDirectory()
        {

            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // iOS 7 and earlier

            return documentsFolder;

        }


        private  AsyncCompletedEventHandler OnDownloadFileCompleted(int id)
        {
            Action<object, AsyncCompletedEventArgs> action = (sender, e) =>
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }

                var itemsInQueue = GetItemsInQueue();
                var itemToRemove = itemsInQueue.FirstOrDefault(item => item.Id == id);

                if (itemToRemove != null)
                    itemsInQueue.Remove(itemToRemove);

                CheckIfAllFinished();

            };
            return new AsyncCompletedEventHandler(action);
        }


        /// <summary>
        /// will check if no items  left wating to be downloaded, if non left will notifay 
        /// </summary>
        private bool CheckIfAllFinished()
        {
            var itemsInQueue = GetNumberOfItemsInQueue();

            if (AllDownloadsCompleted == null || itemsInQueue != 0) return false;

            AllDownloadsCompleted();

            return true;
        }

        /// <summary>
        /// get the files that are wating to be downloaded
        /// </summary>
        /// <returns> list of IItems</returns>
        public List<IItem> GetItemsInQueue()
        {
            return _itemsToDowload ?? (_itemsToDowload = new List<IItem>());
        }


        /// <summary>
        /// will be used to get the number of files that are wating to be downloaded
        /// </summary>
        /// <returns>number of items in the queue list</returns>
        public int GetNumberOfItemsInQueue()
        {
            var itemsList = GetItemsInQueue();

            return itemsList.Count;
        }
    }
}