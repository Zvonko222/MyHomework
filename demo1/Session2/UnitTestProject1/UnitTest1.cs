using Microsoft.VisualStudio.TestTools.UnitTesting;
using Session2;
using Session2.Tools;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Login_CorrectAccount_LoginSuccess()
        {
            // Arrange
            WelcomeForm form = new WelcomeForm();
            // Act
            bool result = form.Login("admin","admin123");

            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckLogin_CorrectPassword_ReturnTrue()
        {
            // Arrange  
            string dbPassword = "admin";
            string password = "admin";

            // Act
            WelcomeForm form = new WelcomeForm();
            bool result = form.CheckLogin(dbPassword, password);
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckLogin_WrongPassword_ReturnFales()
        {
            // Arrange
            string dbPassword = "123";
            string password = "wwww";

            //Act
            WelcomeForm form = new WelcomeForm();
            bool result = form.CheckLogin(dbPassword, password);
            //Assert    
            Assert.IsFalse(result);
        }

        //[TestMethod]
        //public void TestAdd()
        //{
        //    Calculator calculator = new Calculator();
        //    int result = calculator.Add(2, 3);
        //    Assert.AreEqual(5, result);

        //}
    }
}

