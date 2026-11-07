using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isLogin_True()
        {
            LoginForm form = new LoginForm();
            bool result = form.isLogin("123", "123");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void isLogin_false()
        {
            LoginForm form = new LoginForm();
            bool result = form.isLogin("123", "123");
            Assert.IsFalse(result);
        }
    }
}
