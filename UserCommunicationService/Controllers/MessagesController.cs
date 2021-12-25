using Microsoft.AspNetCore.Mvc;
using UserCommunicationService.Controllers.MessagesModels;
using UserCommunicationService.Core.Services.Messages;

namespace UserCommunicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public MessagesController(
            IMessagesService messagesService,
            ILogger<MessagesController> logger)
        {
            _messagesService = messagesService;
            _logger = logger;
        }


        private IMessagesService _messagesService;
        private ILogger<MessagesController> _logger;


        [HttpGet]
        [Route("Info")]
        public string Info()
        {
            return "Developed by Artem B/ Invectys/ Colts Club";
        }
    }
}
