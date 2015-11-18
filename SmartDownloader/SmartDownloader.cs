using System.Collections.Generic;
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
            CheckIfAllFinished();

        }

        /// <summary>
        /// will check if no items  left wating to be downloaded, if non left will notifay 
        /// </summary>
        private void CheckIfAllFinished()
        {
            var itemsInQueue = GetNumberOfItemsInQueue();

            if (AllDownloadsCompleted != null && itemsInQueue == 0)
                AllDownloadsCompleted();
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