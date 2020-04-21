using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeDojo.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            Program program = new Program();
            var numbers = program.GenerateNumbers(50);

            BinarySearchTree tree = BinarySearchTree.Build(numbers);
            Assert.IsNotNull(tree);
        }

        [TestMethod()]
        public void SearchTest()
        {
            Program program = new Program();
            var numbers = program.GenerateNumbers(50);

            BinarySearchTree tree = BinarySearchTree.Build(numbers);
            Assert.AreEqual(true, tree.Search(7));
            Assert.AreEqual(true, tree.Search(55));
            Assert.AreEqual(false, tree.Search(34535));
        }

        [TestMethod()]
        public void AddTest()
        {
            Program program = new Program();
            var numbers = program.GenerateNumbers(50);

            BinarySearchTree tree = BinarySearchTree.Build(numbers);

            tree.Add(21344);
            Assert.AreEqual(true, tree.Search(21344));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Program program = new Program();
            var numbers = program.GenerateNumbers(50);

            BinarySearchTree tree = BinarySearchTree.Build(numbers);

            Assert.AreEqual(true, tree.Search(93));
            tree.Remove(93);
            Assert.AreEqual(false, tree.Search(93));
        }
    }
}