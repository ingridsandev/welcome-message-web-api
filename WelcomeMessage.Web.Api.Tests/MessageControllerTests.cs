using System.Threading.Tasks;
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

        [Theory(DisplayName = "Reason: " +
                              "" +
                              "")]
        [InlineData("StandardDevice", 1, 1)]
        public async Task TestGet(string platformType, int platformId, int appVersion)
        {
            //_messageService
        }
    }
}
