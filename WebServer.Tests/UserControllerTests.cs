

using DataLayer.Models;
using DataLayer;
using Moq;

namespace WebServer.Tests
{
    public class UserControllerTests
    {
        /* Til at mocke test, kan man gøre brug af nedenstående for at mocke sin kontekst
         * mockDataService = new Mock<IDataService>();
         * https://www.webdevtutor.net/blog/moq-in-c-sharp-guide*/

        private readonly DataService dataService;

        public UserControllerTests()
        {
            dataService = new DataService();
        }

        [Fact]
        public void VerifyPassword_WithCorrectPassword_ReturnsTrue()
        {
            // Arrange
            const string correctPassword = "correctPassword";
            var user = new Users { Password = correctPassword };

            // Act
            var result = dataService.VerifyPassword(user, correctPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_WithIncorrectPassword_ReturnsFalse()
        {
            // Arrange
            const string incorrectPassword = "incorrectPassword";
            const string correctPassword = "correctPassword";
            var user = new Users { Password = correctPassword };

            // Act
            var result = dataService.VerifyPassword(user, incorrectPassword);

            // Assert
            Assert.False(result);
        }

        [Fact(Skip = "Denne test kan ikke udføres, da der er tale om en metode, som kalder vores postgres db. Der er derfor tale om en integrationstest")]
        public void GetUserByUsername_WithExistingUsername_ReturnsUser()
        {
            // Arrange
            var mockDataService = new Mock<IDataService>();
            const string existingUsername = "existingUser";

            var user = new Users { UserName = existingUsername };

            mockDataService.Setup(ds => ds.GetUserByUsername(existingUsername)).Returns(user);

            // Act
            // Use the mock object's method
            var result = mockDataService.Object.GetUserByUsername(existingUsername);

            // Assert
            // Check if the result is not null and the usernames match
            Assert.NotNull(result);
            Assert.Equal(existingUsername, result.UserName);
        }


        [Fact(Skip = "Denne test kan ikke udføres, da der er tale om en metode, som kalder vores postgres db. Der er derfor tale om en integrationstest")]
        public void GetUserByUsername_WithNonExistingUsername_ReturnsNull()
        {
            // Arrange
            var mockDataService = new Mock<IDataService>();
            var nonExistingUsername = "nonExistingUser";

            mockDataService.Setup(ds => ds.GetUserByUsername(nonExistingUsername)).Returns<Users>(null);

            // Act
            var result = mockDataService.Object.GetUserByUsername(nonExistingUsername);

            // Assert
            Assert.Null(result);
        }
    }
}