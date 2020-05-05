using System;
using Xunit;

namespace Codecool.LinkedListDojo.UnitTests
{
    public class SinglyLinkedListTests
    {
        private readonly SinglyLinkedList<string> _list;

        public SinglyLinkedListTests()
        {
            _list = new SinglyLinkedList<string>();
            _list.Append("one");
            _list.Append("two");
            _list.Append("three");
            _list.Append("four");
            _list.Append("five");
        }

        [Fact]
        public void Append_OneAndTwo_ToStringContainsAddedElements()
        {
            //Arrange
            var list = new SinglyLinkedList<string>();
            //Act
            list.Append("one");
            list.Append("two");
            //Assert
            Assert.Equal("one two", list.ToString());
        }

        [Fact]
        public void Insert_ThreeAtIndex1_ListContainsThreeAtProperPlace()
        {
            //Act
            _list.Insert(1, "three");
            //Assert
            Assert.Equal("one two three three four five", _list.ToString());
        }

        [Fact]
        public void GetItem_Index2_ReturnThree()
        {
            //Act
            var result = _list.GetItem(2);
            //Assert
            Assert.Equal("three", result.ToString());
        }

        [Fact]
        public void GetLength_FiveAddedElement_Returns5()
        {
            //Act
            var len = _list.GetLength();
            //Assert
            Assert.Equal(5, len);
        }

        [Fact]
        public void Remove_ItemAtIndex2_ListToStringDoesNotContainRemovedItem()
        {
            //Act
            _list.Remove(2);
            //Assert
            Assert.Equal("one two four five", _list.ToString());
        }

        [Fact]
        public void Remove_BiggerIndexThanLength_ThrowsException()
        {
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => { _list.Remove(5); });
        }

        [Fact]
        public void Remove_DeletingHead_RemainingElementsAreRearrangedAccordingly()
        {
            //Act
            _list.Remove(0);
            //Assert
            Assert.Equal("two three four five", _list.ToString());
        }
    }
}