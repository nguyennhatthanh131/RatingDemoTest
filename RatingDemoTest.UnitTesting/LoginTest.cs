using NUnit.Framework;
using RatingDemoTest.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatingDemoTest.UnitTesting
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void Test_Login_Success()
        {
            var demo = new RatingDemoController();
            var loginForSanitationService = demo.AuthenLogin("12345", 1).Result;
            var loginForSercurityService = demo.AuthenLogin("23456", 2).Result;
            var loginForStudentService = demo.AuthenLogin("34567", 3).Result;
            Assert.AreEqual(true, loginForSanitationService);
            Assert.AreEqual(true, loginForSercurityService);
            Assert.AreEqual(true, loginForStudentService);
        }

        [Test]
        public void Test_Login_Fail_With_WrongPasscode()
        {
            var demo = new RatingDemoController();

            var loginForSanitationService = demo.AuthenLogin("987654", 1).Result;
            var loginForSercurityService = demo.AuthenLogin("456789", 2).Result;
            var loginForStudentService = demo.AuthenLogin("12345", 3).Result;

            Assert.AreEqual(false, loginForSanitationService);
            Assert.AreEqual(false, loginForSercurityService);
            Assert.AreEqual(false, loginForStudentService);
        }

        [Test]
        public void Test_Login_Fail_With_CorrectPasscode_WrongService()
        {
            var demo = new RatingDemoController();

            var loginForSanitationService = demo.AuthenLogin("12345", 3).Result;
            var loginForSercurityService = demo.AuthenLogin("23456", 1).Result;
            var loginForStudentService = demo.AuthenLogin("34567", 2).Result;

            Assert.AreEqual(false, loginForSanitationService);
            Assert.AreEqual(false, loginForSercurityService);
            Assert.AreEqual(false, loginForStudentService);
        }
    }
}
