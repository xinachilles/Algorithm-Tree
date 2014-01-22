using ClassLibrary.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm_Tree_Test
{
    
    
    /// <summary>
    ///This is a test class for AVLTreeTest and is intended
    ///to contain all AVLTreeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AVLTreeTest
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
        ///A test for Insert
        ///</summary>
        public void InsertTestHelper()
        {
            AVLTree<int> target = new AVLTree<int>(); // TODO: Initialize to an appropriate value
                  
            target.Insert(1);
            target.Insert(2);
            target.Insert(3);
            

            
            
        }

        [TestMethod()]
        public void InsertTest()
        {
            InsertTestHelper();
        }
    }
}
