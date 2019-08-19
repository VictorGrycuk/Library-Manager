using LibraryManagementCore;
using LibraryManagementCore.Modules.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TestUserManagement
    {
        private readonly Mock<IDataBase> mockedDB;
        private readonly User testUser;
        private readonly UserManagement userManagement;

        public TestUserManagement()
        {
            mockedDB = new Mock<IDataBase>();

            testUser = new User()
            {
                Name = "MockedName",
                LastName = "MockedLastName",
                UserID = "MockedUserID"
            };
            testUser.SetPassword("MockedPassword");

            userManagement = new UserManagement(mockedDB.Object);
        }

        [TestMethod]
        public void AddNewUser_Should_Succeed_With_Unique_UserId()
        {
			// Setup the mocked DB to return an empty list
            mockedDB.Setup(x => x.Find("UserID", It.IsAny<string>())).Returns(new List<object>());

            userManagement.AddNewUser("MockedName", "MockedLastName", "MockedUserID", "MockedPassword");

			// Validate the result
            mockedDB.Verify(x => x.Add(It.Is<User>(y =>
				y.Name == "MockedName" &&
				y.LastName == "MockedLastName" &&
				y.UserID == "MockedUserID"))
			);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The ID MockedUserID already exists.")]
        public void AddNewUser_Should_Fail_With_Duplicate_UserId()
        {
            // Setup the mocked DB to return at least one record
            mockedDB.Setup(x => x.Find("UserID", It.IsAny<string>())).Returns(new List<object>() { testUser });

            userManagement.AddNewUser("MockedName", "MockedLastName", "MockedUserID", "MockedPassword");
        }

        [TestMethod]
		public void FindUserByName_Should_Succeed_When_Returning_Results()
        {
            // Setup the mocked DB to return at least one record
            mockedDB.Setup(x => x.Find("Name", It.IsAny<string>())).Returns(new List<object>() { testUser });

            var result = userManagement.FindByName("MockedName").FirstOrDefault();

            // Validate the result
            Assert.AreEqual(testUser, result);
        }

        [TestMethod]
        public void FindUserByName_Should_Not_Fail_When_Not_Returning_Results()
        {
            // Setup the mocked DB to return an empty list
            mockedDB.Setup(x => x.Find("Name", It.IsAny<string>())).Returns(new List<object>());

            var result = userManagement.FindByName("MockedName").FirstOrDefault();

            // Validate the result
            Assert.AreEqual(result, null);
        }
    }
}
