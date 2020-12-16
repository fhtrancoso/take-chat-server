using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Take.Chat.Business.Contract;
using Take.Chat.Converters;
using Take.Chat.Model;

namespace Take.Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly IMessageManager _manager;

        public MessagesController(IMessageManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] [Required] Message value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _manager.SendMessage(value.ToModel());
                return new OkResult();
            }
            catch (System.Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetAllMessages()
        {
            try
            {
                var messages = _manager.GetAllMessages();

                return new OkObjectResult(messages);
            }
            catch (System.Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}