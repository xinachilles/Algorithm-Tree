using ClassLibrary.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithm_Tree_Test
{
    
    
    /// <summary>
    ///This is a test class for BinaryTreeTest and is intended
    ///to contain all BinaryTreeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BinaryTreeTest
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
        ///A test for CheckBST
        ///</summary>
        public void CheckBSTTestHelper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value
            
                target.Add(0);
                target.Add(1);
                target.Add(7);
                target.Add(3);
                target.Add(4); 
                target.Add(5); 
                target.Add(6);

                                            
            bool actual  = target.CheckBST(target.root);
            
        }

        [TestMethod()]
        public void CheckBSTTest()
        {
            CheckBSTTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value
            target.Add(1);
            target.Add(2);
            target.Add(3);
            target.Add(4);
            target.Add(5);
            }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for CheckBST
        ///</summary>
        public void CheckBSTTest1Helper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value
            target.Add(1);
            target.Add(2);
            target.Add(3);
            target.Add(4);
            target.Add(5);
            target.CheckBST(target.root, int.MinValue, int.MaxValue);
        }

        [TestMethod()]
        public void CheckBSTTest1()
        {
            CheckBSTTest1Helper<GenericParameterHelper>();
        }



        /// <summary>
        ///A test for CreateLevellinkedListTwo
        ///</summary>
        public void CreateLevellinkedListTwoTestHelper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value

            target.Add(0);
            target.Add(1);
            target.Add(2);
            target.Add(3);
            target.Add(4);
            target.Add(5);

           target.CreateLevellinkedListTwo(target.root);
            
        }

        [TestMethod()]
        public void CreateLevellinkedListTwoTest()
        {
            CreateLevellinkedListTwoTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for InorderTraversalWhileLoop
        ///</summary>
        public void InorderTraversalWhileLoopTestHelper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value
            target.root = new TreeNode<int>(0);
            target.root.left = new TreeNode<int>(1);
            target.root.right = new TreeNode<int>(2);
            target.root.left.left = new TreeNode<int>(3);
            target.root.left.left.left = new TreeNode<int>(4);
            target.root.left.left.right = new TreeNode<int>(5);
            target.root.right.left = new TreeNode<int>(6);
            target.root.right.right = new TreeNode<int>(7);
            target.root.right.right.left = new TreeNode<int>(8);

            
            target.InorderTraversalWhileLoop(target.root);
        }

        [TestMethod()]
        public void InorderTraversalWhileLoopTest()
        {
            InorderTraversalWhileLoopTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for InorderTraversal
        ///</summary>
        public void InorderTraversalTestHelper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value
            target.Add(0);
            target.Add(1);
            target.Add(2);
            target.Add(3);
            target.Add(4);
            target.Add(5);

            target.InorderTraversal(target.root);

        }

        [TestMethod()]
        public void InorderTraversalTest()
        {
            InorderTraversalTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for CommonAncerstorProvedSolutionThree
        ///</summary>
        public void CommonAncerstorProvedSolutionThreeTestHelper<T>()
        {
            BinaryTree<int> target = new BinaryTree<int>(); // TODO: Initialize to an appropriate value

            int[] data = new int[7];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }

            for (int i = 0; i < data.Length; i++)
            {
                target.Add(data[i]);
            }


            TreeNode<int> root = target.root; // TODO: Initialize to an appropriate value

            // case 1: two notes in the same subtree

            //TreeNode<int> p = target.root.left.right.left ; // TODO: Initialize to an appropriate value
            //TreeNode<int> q = target.root.left; // TODO: Initialize to an appropriate value


            // case 2 :two notes in the differet subtree
            TreeNode<int> p = target.root.left.left; // TODO: Initialize to an appropriate value
            TreeNode<int> q = target.root.right.right; // TODO: Initialize to an appropriate value

            TreeNode<int> expected = target.root; // TODO: Initialize to an appropriate value

            TreeNode<int> actual = target.CommonAncerstorProvedSolutionThree(root, p, q);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CommonAncerstorProvedSolutionThreeTest()
        {
            CommonAncerstorProvedSolutionThreeTestHelper<GenericParameterHelper>();
        }
    }
}
