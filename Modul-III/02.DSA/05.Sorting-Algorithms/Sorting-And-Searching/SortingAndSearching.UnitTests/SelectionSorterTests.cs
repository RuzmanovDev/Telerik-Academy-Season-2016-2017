using NUnit.Framework;
using SortingHomework;

namespace SortingAndSearching.UnitTests
{
    [TestFixture]
    public class SelectionSorterTests
    {
        [Test]
        public void Sort_ShouldSortCorretlyArrayOfIntegers()
        {
            var sorter = new SelectionSorter<int>();
            var nums = new SortableCollection<int>(new[] { -4, 0, 1, 2, 22, 233 });
            var sorted = new SortableCollection<int>(new[] { -4, 0, 1, 2, 22, 233 });

            nums.Sort(sorter);
            CollectionAssert.AreEqual(nums, sorted);
        }

        [Test]
        public void Sort_ShouldSortCorretlyArrayOfChars()
        {
            var sorter = new SelectionSorter<char>();
            var nums = new SortableCollection<char>(new[] { 'c', 'a', 'z', });
            var sorted = new SortableCollection<char>(new[] { 'a', 'c', 'z' });

            nums.Sort(sorter);
            CollectionAssert.AreEqual(nums, sorted);
        }
    }
}
