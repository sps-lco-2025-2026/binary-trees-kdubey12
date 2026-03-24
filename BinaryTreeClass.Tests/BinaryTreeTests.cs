namespace BinaryTreeClass.Tests;
using BinaryTreeClass.Lib;

[TestClass]
public sealed class BinaryTreeTests
{

    [TestMethod]
    public void TestToString()
    {
        BinaryTree bt = new BinaryTree(5);
        bt.Insert(7);
        bt.Insert(3);
        bt.Insert(4);
        bt.Insert(2);

        Assert.AreEqual("{2, 3, 4, 5, 7}", bt.ToString());
    }

    [TestMethod]
    public void TestContains()
    {
        BinaryTree bt = new BinaryTree(5);
        bt.Insert(7);
        bt.Insert(3);
        bt.Insert(4);
        bt.Insert(2);

        Assert.IsTrue(bt.Contains(4));
    }

    [TestMethod]
    public void TestSum()
    {
        BinaryTree bt = new BinaryTree(5);
        bt.Insert(7);
        bt.Insert(3);
        bt.Insert(4);
        bt.Insert(2);

        Assert.AreEqual(21, bt.Sum());
    }

    [TestMethod]
    public void TestDuplicates()
    {
        BinaryTree bt = new BinaryTree(5);
        bt.Insert(7);
        bt.Insert(3);
        bt.Insert(4);
        bt.Insert(5);
        bt.Insert(3);
        bt.Insert(2);

        Assert.IsTrue(bt.HasDuplicates());
    }

    [TestMethod]
    public void TestDepth()
    {
        BinaryTree bt = new BinaryTree(10);
        bt.Insert(4);
        bt.Insert(6);
        bt.Insert(3);
        bt.Insert(2);
        bt.Insert(12);
        bt.Insert(11);
        bt.Insert(11);

        Assert.AreEqual(3, bt.Depth());
    }
}
