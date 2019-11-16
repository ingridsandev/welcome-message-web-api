using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using WelcomeMessage.Web.Api.Services;

namespace WelcomeMessage.Web.Api.Tests
{
    public class MessageControllerTests
    {
        private readonly IMessageService _messageService;

        public MessageControllerTests()
        {
            _messageService = new MessageService();
        }

        [Theory(DisplayName = "Test should return old value - Platform id THREE does not implement new value")]
        [InlineData(3, "SpecialDevice", 1)]
        [InlineData(3, "StandardDevice", 1)]
        [InlineData(3, "SpecialDevice", 2)]
        [InlineData(3, "StandardDevice", 2)]
        [InlineData(3, "SpecialDevice", 3)]
        [InlineData(3, "StandardDevice", 3)]
        public void TestsShouldReturnOldValueDuePlatformIdThreeDoesNotSupportNewVersion(int platformId, string platformType, int appVersion)
        {
            // Act
            var response = _messageService.GetWelcomeMessage(platformId, platformType, appVersion);

            // Assert
            response.Should().Be(Messages.OldValue);
        }

        [Theory(DisplayName = "Test should return new value - AppVersion  is greater or equal 3")]
        [InlineData(1, "SpecialDevice", 3)]
        [InlineData(2, "SpecialDevice", 3)]
        [InlineData(4, "SpecialDevice", 3)]
        [InlineData(1, "StandardDevice", 3)]
        [InlineData(2, "StandardDevice", 3)]
        [InlineData(4, "StandardDevice", 3)]
        public void TestsShouldReturnNewValue(int platformId, string platformType, int appVersion)
        {
            // Act
            var response = _messageService.GetWelcomeMessage(platformId, platformType, appVersion);

            // Assert
            response.Should().Be(Messages.NewValue);
        }

        [Theory(DisplayName = "Should return null due platform id not implemented")]
        [InlineData(5, "SpecialDevice", 3)]
        [InlineData(5, "StandardDevice", 3)]
        public void PlatformIdNotImplemented(int platformId, string platformType, int appVersion)
        {
            // Act
            var response = _messageService.GetWelcomeMessage(platformId, platformType, appVersion);

            // Assert
            response.Should().BeNullOrEmpty();
        }

        [Theory(DisplayName = "Special devices from platform 1 and 2 using app version 1 should always return old value")]
        [InlineData(1, "SpecialDevice", 1)]
        [InlineData(2, "SpecialDevice", 1)]
        public void SpecialDevicesFromPlatform1And2UsingAppVersion1ShouldAlwaysReturnOldValue(int platformId, string platformType, int appVersion)
        {
            // Act
            var response = _messageService.GetWelcomeMessage(platformId, platformType, appVersion);

            // Assert
            response.Should().Be(Messages.OldValue);
        }

        [Theory(DisplayName = "Tests should return old value due app version is lower than current")]
        
        [InlineData(1, "SpecialDevice", 2)]

        [InlineData(2, "SpecialDevice", 2)]
 
        [InlineData(4, "SpecialDevice", 2)]
        [InlineData(4, "SpecialDevice", 1)]

        [InlineData(1, "StandardDevice", 1)]
        [InlineData(1, "StandardDevice", 2)]

        [InlineData(2, "StandardDevice", 1)]
        [InlineData(2, "StandardDevice", 2)]

        [InlineData(4, "StandardDevice", 1)]
        [InlineData(4, "StandardDevice", 2)]
        public void TestsShouldReturnOldValueDueAppVersionIsLowerThanCurrent(int platformId, string platformType, int appVersion)
        {
            // Act
            var response = _messageService.GetWelcomeMessage(platformId, platformType, appVersion);

            // Assert
            response.Should().Be(Messages.OldValue);
        }
    }
}
