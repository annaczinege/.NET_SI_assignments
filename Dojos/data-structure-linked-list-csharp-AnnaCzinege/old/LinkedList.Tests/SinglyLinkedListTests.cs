using NUnit.Framework;
using System;

namespace LinkedList.Tests
{
    [TestFixture()]
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<string> _list;

        [SetUp]
        public void SetupTests()
        {
            _list = new SinglyLinkedList<string>();
            _list.Append("one");
            _list.Append("two");
            _list.Append("three");
            _list.Append("four");
            _list.Append("five");
        }

        [Test()]
        public void Append_OneAndTwo_ToStringContainsAddedElements()
        {
            //Arrange
            var list = new SinglyLinkedList<string>();
            //Act
            list.Append("one");
            list.Append("two");
            //Assert
            Assert.AreEqual("one two", list.ToString());
        }

        [Test()]
        public void Insert_ThreeAtIndex1_ListContainsThreeAtProperPlace()
        {
            //Act
            _list.Insert(1, "three");
            //Assert
            Assert.AreEqual("one two three three four five", _list.ToString());
        }

        [Test()]
        public void GetItem_Index2_ReturnThree()
        {
            //Act
            var result = _list.GetItem(2);
            //Assert
            Assert.AreEqual("three", result.ToString());
        }

        [Test()]
        public void GetLength_FiveAddedElement_Returns5()
        {
            //Act
            var len = _list.GetLength();
            //Assert
            Assert.AreEqual(5, len);
        }

        [Test()]
        public void Remove_ItemAtIndex2_ListToStringDoesntContainRemovedItem()
        {
            //Act
            _list.Remove(2);
            //Assert
            Assert.AreEqual("one two four five", _list.ToString());
        }

        [Test()]
        public void Remove_BiggerIndexThanLength_ThrowsException()
        {
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => { _list.Remove(5); });
        }

        [Test()]
        public void Remove_DeletingHead_RemainingElementsAreRearrangedAccordingly()
        {
            //Act
            _list.Remove(0);
            //Assert
            Assert.AreEqual("two three four five", _list.ToString());
        }
    }
}