using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CollectionQueueTests
{
    [TestFixture]
    public class QueueNUnitTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 7, 8 }, 9)]
        [TestCase(new[] { 1 }, 2)]
        public void EnqueueTest(int[] array, int item)
        {
            var queue = new Queue<int>(array);
            queue.Enqueue(item);
            var positionNewElement = array.Length + 1;
            Assert.AreEqual(array.Length + 1, queue.Count);
            Assert.IsTrue(queue.Contains(item));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1 })]
        public void DequeueTest(int[] array)
        {
            var queue = new Queue<int>(array);
            var element = queue.Dequeue();
            Assert.AreEqual(array[0], element);
            Assert.AreEqual(array.Length - 1, queue.Count);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1 })]
        public void ClearTest(int[] array)
        {
            var queue = new Queue<int>(array);
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 7, 9 }, 4)]
        [TestCase(new[] { 1 }, 1)]
        public void ContainsTest_Positive(int[] array, int item)
        {
            var queue = new Queue<int>(array);
            Assert.IsTrue(queue.Contains(item));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, -1)]
        [TestCase(new[] { 1 }, 0)]
        public void ContainsTest_Negative(int[] array, int item)
        {
            var queue = new Queue<int>(array);
            Assert.IsFalse(queue.Contains(item));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1 })]
        public void ToArrayTest(int[] array)
        {
            var queue = new Queue<int>(array);
            Assert.IsTrue(array.SequenceEqual(queue.ToArray()));
        }


    }
}
