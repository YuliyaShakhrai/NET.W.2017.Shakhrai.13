using System;
using System.Collections.Generic;
using CollectionBinarySearchTree;
using NUnit.Framework;

namespace CollectionBinarySearchTreeTests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region BinarySearchTree<int> tests

        [Test]
        public void BinarySearchTree_Int_InsertTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var testTree = new BinarySearchTree<int>(items);

            testTree.Insert(5);

            Assert.AreEqual(items.Length + 1, testTree.Count);
            Assert.IsTrue(testTree.Contains(5));
        }

        [Test]
        public void BinarySearchTree_Int_Insert_ThrowArgumentNullException()
        {
            var testTree = new BinarySearchTree<int>();

            Assert.Throws<ArgumentNullException>(() => testTree.Insert(null));
        }

        [Test]
        public void BinarySearchTree_Int_Remove_PositiveTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var testTree = new BinarySearchTree<int>(items);

            testTree.Remove(7);

            Assert.AreEqual(items.Length - 1, testTree.Count);
            Assert.IsFalse(testTree.Contains(7));
        }

        [Test]
        public void BinarySearchTree_Int_Remove_NegativeTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var testTree = new BinarySearchTree<int>(items);

            testTree.Remove(1);

            Assert.AreEqual(items.Length, testTree.Count);
        }

        [Test]
        public void BinarySearchTree_Int_ClearTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var testTree = new BinarySearchTree<int>(items);

            testTree.Clear();

            Assert.Zero(testTree.Count);
            Assert.Null(testTree.Root);
        }

        [Test]
        public void BinarySearchTree_Int_MemberwiseClearTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var testTree = new BinarySearchTree<int>(items);

            testTree.MemberwiseClear();

            Assert.Zero(testTree.Count);
            Assert.Null(testTree.Root);
        }

        [Test]
        public void BinarySearchTree_Int_TraverseTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var testTree = new BinarySearchTree<int>(items);
            var inOrderTree = new int[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            var preOrderTree = new int[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new int[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new int[] { 2, 6, 7, 8, 9, 11, 12, 13 }, inOrderTree);
            CollectionAssert.AreEqual(new int[] { 9, 8, 7, 6, 2, 11, 12, 13 }, preOrderTree);
            CollectionAssert.AreEqual(new int[] { 2, 6, 7, 8, 13, 12, 11, 9 }, postOrderTree);
        }

        [Test]
        public void BinarySearchTree_Int_Comparer_TraverseTest()
        {
            int[] items = { 9, 8, 7, 6, 11, 12, 13, 2 };
            var comparer = new IntComparer();
            var testTree = new BinarySearchTree<int>(items, comparer);
            var inOrderTree = new int[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            int[] preOrderTree = new int[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new int[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new int[] { 13, 12, 11, 9, 8, 7, 6, 2 }, inOrderTree);
            CollectionAssert.AreEqual(new int[] { 9, 11, 12, 13, 8, 7, 6, 2 }, preOrderTree);
            CollectionAssert.AreEqual(new int[] { 13, 12, 11, 2, 6, 7, 8, 9 }, postOrderTree);
        }

        #endregion

        #region BinarySearchTree<string> tests

        [Test]
        public void BinarySearchTree_String_Remove_PositiveTest()
        {
            string[] items = { "nnn", "aaa", "ccc", "ddd", "zzz", "yyy", "www", "xxx" };
            var testTree = new BinarySearchTree<string>(items);

            testTree.Remove("ccc");

            Assert.AreEqual(items.Length - 1, testTree.Count);
            Assert.IsFalse(testTree.Contains("ccc"));
        }

        [Test]
        public void BinarySearchTree_String_Remove_NegativeTest()
        {
            string[] items = { "nnn", "aaa", "ccc", "ddd", "zzz", "yyy", "www", "xxx" };
            var testTree = new BinarySearchTree<string>(items);

            testTree.Remove("bbb");

            Assert.AreEqual(items.Length, testTree.Count);
        }

        [Test]
        public void BinarySearchTree_String_TraverseTest()
        {
            string[] items = { "nnn", "aaa", "ccc", "ddd", "zzz", "yyy", "www", "xxx" };
            var testTree = new BinarySearchTree<string>(items);
            var inOrderTree = new string[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            var preOrderTree = new string[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new string[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new string[] { "aaa", "ccc", "ddd", "nnn", "www", "xxx", "yyy", "zzz" }, inOrderTree);
            CollectionAssert.AreEqual(new string[] { "nnn", "aaa", "ccc", "ddd", "zzz", "yyy", "www", "xxx" }, preOrderTree);
            CollectionAssert.AreEqual(new string[] { "ddd", "ccc", "aaa", "xxx", "www", "yyy", "zzz", "nnn" }, postOrderTree);
        }

        [Test]
        public void BinarySearchTree_String_Comparer_TraverseTest()
        {
            string[] items = { "333", "22", "4444", "1", "55555", "88888888", "666666", "7777777" };
            var comparer = new StringComparer();
            var testTree = new BinarySearchTree<string>(items, comparer);
            var inOrderTree = new string[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            var preOrderTree = new string[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new string[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new string[] { "1", "22", "333", "4444", "55555", "666666", "7777777", "88888888" }, inOrderTree);
            CollectionAssert.AreEqual(new string[] { "333", "22", "1", "4444", "55555", "88888888", "666666", "7777777" }, preOrderTree);
            CollectionAssert.AreEqual(new string[] { "1", "22", "7777777", "666666", "88888888", "55555", "4444", "333" }, postOrderTree);
        }

        #endregion

        #region BinarySearchTree<Book> tests

        [Test]
        public void BinarySearchTree_Book_Remove_PositiveTest()
        {
            var book1 = new Book("001", "author", "title", "pub", 2000, 50, 15);
            var book2 = new Book("002", "author", "title", "pub", 2000, 50, 15);
            var book3 = new Book("003", "author", "title", "pub", 2000, 50, 15);
            var book4 = new Book("004", "author", "title", "pub", 2000, 50, 15);
            Book[] items = { book1, book2, book3, book4 };
            var testTree = new BinarySearchTree<Book>(items);

            testTree.Remove(book2);

            Assert.AreEqual(items.Length - 1, testTree.Count);
            Assert.IsFalse(testTree.Contains(book2));
        }

        [Test]
        public void BinarySearchTree_Book_Remove_NegativeTest()
        {
            var book1 = new Book("001", "author", "title", "pub", 2000, 50, 15);
            var book2 = new Book("002", "author", "title", "pub", 2000, 50, 15);
            var book3 = new Book("003", "author", "title", "pub", 2000, 50, 15);
            var book4 = new Book("004", "author", "title", "pub", 2000, 50, 15);
            Book[] items = { book1, book2, book3, book4 };
            var testTree = new BinarySearchTree<Book>(items);
            var book5 = new Book("005", "author", "title", "pub", 2000, 50, 15);

            testTree.Remove(book5);

            Assert.AreEqual(items.Length, testTree.Count);
        }

        [Test]
        public void BinarySearchTree_Book_TraverseTest()
        {
            var book1 = new Book("title1", "author", "001", "pub", 2000, 50, 15);
            var book2 = new Book("title2", "author", "002", "pub", 2000, 50, 15);
            var book3 = new Book("title3", "author", "003", "pub", 2000, 50, 15);
            var book4 = new Book("title4", "author", "004", "pub", 2000, 50, 15);
            var book5 = new Book("title5", "author", "005", "pub", 2000, 50, 15);
            var book6 = new Book("title6", "author", "006", "pub", 2000, 50, 15);
            Book[] items = { book2, book3, book1, book4, book5, book6 };
            var testTree = new BinarySearchTree<Book>(items);
            var inOrderTree = new Book[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            var preOrderTree = new Book[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new Book[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new Book[] { book1, book2, book3, book4, book5, book6 }, inOrderTree);
            CollectionAssert.AreEqual(new Book[] { book2, book1, book3, book4, book5, book6 }, preOrderTree);
            CollectionAssert.AreEqual(new Book[] { book1, book6, book5, book4, book3, book2 }, postOrderTree);
        }

        [Test]
        public void BinarySearchTree_Book_Comparer_TraverseTest()
        {
            var book1 = new Book("a", "author", "001", "pub", 2000, 50, 15);
            var book2 = new Book("aa", "author", "002", "pub", 2000, 50, 15);
            var book3 = new Book("aaa", "author", "003", "pub", 2000, 50, 15);
            var book4 = new Book("aaaa", "author", "004", "pub", 2000, 50, 15);
            var book5 = new Book("aaaaa", "author", "005", "pub", 2000, 50, 15);
            var book6 = new Book("aaaaaa", "author", "006", "pub", 2000, 50, 15);
            Book[] items = { book2, book3, book1, book4, book5, book6 };
            var comparer = new BookComparer();
            var testTree = new BinarySearchTree<Book>(items, comparer);
            var inOrderTree = new Book[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            var preOrderTree = new Book[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new Book[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new Book[] { book1, book2, book3, book4, book5, book6 }, inOrderTree);
            CollectionAssert.AreEqual(new Book[] { book2, book1, book3, book4, book5, book6 }, preOrderTree);
            CollectionAssert.AreEqual(new Book[] { book1, book6, book5, book4, book3, book2 }, postOrderTree);
        }

        #endregion

        #region BinarySearchTree<Point> tests

        [Test]
        public void BinarySearchTree_Point_Remove_PositiveTest()
        {
            Point point1 = new Point(10, 10);
            Point point2 = new Point(20, 20);
            Point point3 = new Point(30, 30);
            Point point4 = new Point(40, 40);
            Point[] items = new Point[] { point1, point2, point3, point4 };
            var comparer = new PointComparer();
            var testTree = new BinarySearchTree<Point>(items, comparer);

            testTree.Remove(point2);

            Assert.AreEqual(items.Length - 1, testTree.Count);
            Assert.IsFalse(testTree.Contains(point2));
        }

        [Test]
        public void BinarySearchTree_Point_Remove_NegativeTest()
        {
            var point1 = new Point(10, 10);
            var point2 = new Point(20, 20);
            var point3 = new Point(30, 30);
            var point4 = new Point(40, 40);
            Point[] items = new Point[] { point1, point2, point3, point4 };
            var comparer = new PointComparer();
            var testTree = new BinarySearchTree<Point>(items, comparer);
            var point5 = new Point(50, 50);

            testTree.Remove(point5);

            Assert.AreEqual(items.Length, testTree.Count);
        }

        [Test]
        public void BinarySearchTree_Point_Comparer_TraverseTest()
        {
            var point1 = new Point(10, 10);
            var point2 = new Point(20, 20);
            var point3 = new Point(30, 30);
            var point4 = new Point(40, 40);
            var point5 = new Point(50, 50);
            var point6 = new Point(60, 60);
            var point7 = new Point(70, 70);
            Point[] items = new Point[] { point2, point1, point6, point3, point5, point4, point7 };
            var comparer = new PointComparer();
            var testTree = new BinarySearchTree<Point>(items, comparer);
            var inOrderTree = new Point[testTree.Count];
            int i = 0;
            foreach (var item in testTree.InOrder())
            {
                inOrderTree[i] = item;
                i++;
            }

            var preOrderTree = new Point[testTree.Count];
            i = 0;
            foreach (var item in testTree.PreOrder())
            {
                preOrderTree[i] = item;
                i++;
            }

            var postOrderTree = new Point[testTree.Count];
            i = 0;
            foreach (var item in testTree.PostOrder())
            {
                postOrderTree[i] = item;
                i++;
            }

            CollectionAssert.AreEqual(new Point[] { point1, point2, point3, point4, point5, point6, point7 }, inOrderTree);
            CollectionAssert.AreEqual(new Point[] { point2, point1, point6, point3, point5, point4, point7 }, preOrderTree);
            CollectionAssert.AreEqual(new Point[] { point1, point4, point5, point3, point7, point6, point2 }, postOrderTree);
        }

        #endregion

        #region Struct Point

        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        #endregion

        #region Comparers

        private class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        private class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Length.CompareTo(y.Length);
            }
        }

        private class BookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return x.Title.Length.CompareTo(y.Title.Length);
            }
        }

        private class PointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return x.X.CompareTo(y.X);
            }
        }

        #endregion
    }
}
