using NUnit.Framework;
using SortingHomework;

namespace SortingAndSearching.UnitTests
{
    [TestFixture]
    public class SortableCollectionTests
    {
        [Test]
        public void LineraSearch_ShouldReturnTrue_WhenvalueIsPresent()
        {
            var collection = new SortableCollection<int>(new[] { 3, 2, 4 });
            var valueToFind = 2;

            var found = collection.LinearSearch(valueToFind);

            Assert.IsTrue(found);
        }

        public void LineraSearch_ShouldReturnFalse_WhenValueIsNotPresent()
        {
            var collection = new SortableCollection<int>(new[] { 3, 2, 4 });
            var valueToFind = 112;

            var found = collection.LinearSearch(valueToFind);

            Assert.IsFalse(found);
        }

        [Test]
        public void BinarySearch_ShouldReturnTrue_WhenvalueIsPresent()
        {
            var collection = new SortableCollection<int>(new[] { 3, 2, 4 });
            var valueToFind = 2;

            var found = collection.BinarySearch(valueToFind);

            Assert.IsTrue(found);
        }

        [Test]
        public void BinarySearch_ShouldRetrunFalse_WhenValueIsNotPresent()
        {
            var collection = new SortableCollection<int>(new[] { 3, 2, 4 });
            var valueToFind = 112;

            var found = collection.BinarySearch(valueToFind);

            Assert.IsFalse(found);
        }

        [Test]
        public void Shuffle_ShouldWorkCoretly()
        {
            var initial = new SortableCollection<int>(new[] { 3, 2, 4, 4, 2, 1, 2, 23, 4, -2 });
            var collectionToShuffle = new SortableCollection<int>(new[] { 3, 2, 4, 4, 2, 1, 2, 23, 4, -2 });

            collectionToShuffle.Shuffle();

            CollectionAssert.AreNotEqual(initial, collectionToShuffle);
        }
    }
}
