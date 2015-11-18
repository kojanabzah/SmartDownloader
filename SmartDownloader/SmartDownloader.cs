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
            _itemsToDowload = new List<IItem>();
            
        }

        public void AddFileToQueue(IItem item)
        {
            //Not Sure i want to init _itemsToDowload my self here , its better user will use the ctr to do this .
            if(_itemsToDowload == null)
                throw new System.NullReferenceException("_itemsToDowload cannot be null,pease check that you initialized SmartDownloader");

            _itemsToDowload.Add(item);
        }

        public void StartDownloading()
        {
            //Not Sure i want to init _itemsToDowload my self here , its better user will use the ctr to do this .
            if (_itemsToDowload == null)
                throw new System.NullReferenceException("_itemsToDowload cannot be null,pease check that you initialized SmartDownloader");

            CheckIfAllFinished();





        }

        private void CheckIfAllFinished()
        {
            if (AllDownloadsCompleted != null && _itemsToDowload.Count == 0)
                AllDownloadsCompleted();
        }
        

    }
}