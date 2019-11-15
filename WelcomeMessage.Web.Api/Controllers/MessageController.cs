using Microsoft.AspNetCore.Mvc;
using WelcomeMessage.Web.Api.Services;

namespace WelcomeMessage.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public string GetWelcomeMessage(int platformId, string platformType, int appVersion) =>
            _messageService.GetWelcomeMessage(platformId, platformType, appVersion);
    }
}
