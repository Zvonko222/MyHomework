using Microsoft.VisualStudio.TestTools.UnitTesting;
using Session2.Tools;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);

        }
    }
}

