using System.Collections.Generic;
using Android.Widget;

namespace kojan.SmartDownloader
{
    public delegate void MyVoidDelegate();   // delegate declaration

    public class SmartDownloader
    {
        public event MyVoidDelegate AllDownloadsCompleted;



        private List<IItem> _itemsToDowload; 
        

        public SmartDownloader()
        {
            
        }

        public void AddFileToQueue(IItem item)
        {
            var itemsList = GetItemsInQueue();

            itemsList.Add(item);
        }

        public void StartDownloading()
        {
            CheckIfAllFinished();

        }

        private void CheckIfAllFinished()
        {
            var itemsList = GetItemsInQueue();

            if (AllDownloadsCompleted != null && itemsList.Count == 0)
                AllDownloadsCompleted();
        }


        public List<IItem> GetItemsInQueue()
        {
            return _itemsToDowload ?? (_itemsToDowload = new List<IItem>());
        }

        public int GetNumberOfItemsInQueue()
        {
            var itemsList = GetItemsInQueue();

            return itemsList.Count;
        }
    }
}