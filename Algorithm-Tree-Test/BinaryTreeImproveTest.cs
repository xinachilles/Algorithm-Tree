using ClassLibrary.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm_Tree_Test
{
    
    
    /// <summary>
    ///This is a test class for BinaryTreeImproveTest and is intended
    ///to contain all BinaryTreeImproveTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BinaryTreeImproveTest
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
        ///A test for Track
        ///</summary>
        [TestMethod()]
        public void TrackTest()
        {
            BinaryTreeImprove target = new BinaryTreeImprove(); // TODO: Initialize to an appropriate value
           
            target.Track(20);
            target.Track(15);
            target.Track(25);
            target.Track(10);
            target.Track(5);
            target.Track(13);
            target.Track(23);
            target.Track(24);
            
        }
    }
}
