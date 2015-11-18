using kojan.SmartDownloader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartDownloaderUnitTests
{
    /// <summary>
    /// Summary description for SmartDownloaderUnitTest
    /// </summary>
    [TestClass]
    public class SmartDownloaderUnitTest
    {
        private SmartDownloader smartDownloader;

        [TestInitialize()] 
        public void SmartDownloaderInitialize()
        {
            smartDownloader = new SmartDownloader();
        }

        
        [TestMethod]
        public void AddFileToQueueTest()
        {
            var itemCount = smartDownloader.GetNumberOfItemsInQueue();
            Assert.AreEqual(itemCount, 0);

            smartDownloader.AddFileToQueue(new Item());

            itemCount = smartDownloader.GetNumberOfItemsInQueue();
            Assert.AreEqual(itemCount, 1);
            
        }

        
       
    }
}
