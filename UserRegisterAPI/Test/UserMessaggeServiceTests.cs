using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using UserRegisterAPI.Application;
using UserRegisterAPI.Domain;
using UserRegisterAPI.Domain.Contracts;
using Xunit;

namespace UserRegisterAPI.Test
{
    public class UserMessaggeServiceTests
    {
        [Fact]
        public void GetAllUsers_ShouldReturnUsers()
        {
            var mockRepository = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserMessageService>>();
            var service = new UserMessageService(mockRepository.Object, mockLogger.Object);
            var users = new List<User>
            {  
                new User {Name = "Luis", PhoneNumber = "12345666" },
                new User {Name = "Sandra", PhoneNumber = "987456333" }
            };

            mockRepository.Setup(r => r.GetAllUsers()).Returns(users);

            var result = service.GetAllUsers();
            Assert.Equal(users, result);
        }

        [Fact]
        public void AddUser_ShouldLogMessagge()
        {
            var mockRepository = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserMessageService>>();
            var service = new UserMessageService(mockRepository.Object, mockLogger.Object);
            var user = new User { Name = "Luis", PhoneNumber = "12345666" };

            service.RegisterUser(user);

            mockRepository.Verify(r => r.AddUser(user), Times.Once);
            mockLogger.Verify(l => l.LogInformation(It.IsAny<string>()), Times.Once);
        }

    }
}
