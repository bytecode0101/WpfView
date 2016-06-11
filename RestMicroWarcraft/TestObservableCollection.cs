using Assets.MicroWarcraft.Utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace RestMicroWarcraft
{
    [TestFixture]
    public class TestObservableCollection
    {
        [Test]
        public void TestAddItems()
        {
            ObservableCollection<int> myCollection = new ObservableCollection<int>();
            Assert.AreEqual(0, myCollection.Count);
            myCollection.Add(1);
            Assert.AreEqual(1, myCollection.Count);
        }

        [Test]
        public void TestCollectionChanged()
        {
            ObservableCollection<int> myCollection = new ObservableCollection<int>();
            var eventTriggered = false;
            myCollection.CollectionChanged += (sender, arg) => {
                eventTriggered = true;
                var newItems = new List<object>(arg.NewItems);
                Assert.AreEqual(1, newItems.Count);
            };        
            Assert.AreEqual(0, myCollection.Count);
            Assert.AreEqual(eventTriggered, false);
            myCollection.Add(1);
            Assert.AreEqual(1, myCollection.Count);
            Assert.AreEqual(eventTriggered, true);
        }
    }
}
