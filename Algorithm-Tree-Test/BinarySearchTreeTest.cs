using ClassLibrary.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm_Tree_Test
{
    
    
    /// <summary>
    ///This is a test class for BinarySearchTreeTest and is intended
    ///to contain all BinarySearchTreeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BinarySearchTreeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for InorderSucc
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Algorithm-Tree.dll")]
        public void InorderSuccTest()
        {
            BinarySearchTree_Accessor target = new BinarySearchTree_Accessor(); // TODO: Initialize to an appropriate value
            target.root = new TreeNode<int>(0);

            target.root.left = new TreeNode<int>(1);
            target.root.left.parent = target.root;

            target.root.right = new TreeNode<int>(2);
            target.root.right.parent = target.root;

            target.root.left.left = new TreeNode<int>(3);
            target.root.left.left.parent = target.root.left;
            
            target.root.left.left.left = new TreeNode<int>(4);
            target.root.left.left.left.parent = target.root.left.left;
            
            target.root.left.left.right = new TreeNode<int>(5);
            target.root.left.left.right.parent = target.root.left.left;

            target.root.right.left = new TreeNode<int>(6);
            target.root.right.left.parent = target.root.right;

            target.root.right.right = new TreeNode<int>(7);
            target.root.right.right.parent = target.root.right;

            target.root.right.right.left = new TreeNode<int>(8);
            target.root.right.right.left.parent = target.root.right.right;


            TreeNode<int> expected = target.root;
            TreeNode<int> actual = target.InorderSucc(target.root.left);
            Assert.AreEqual(expected, actual);
          
        }
    }
}
