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
    public class UsersController : Controller
    {
        private readonly IUserManager _manager;

        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] [Required] User value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var response = _manager.InsertValidUser(value.ToModel());
                return new OkObjectResult(response);
            }
            catch (System.Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetUserByName(string value)
        {
            try
            {
                var user = _manager.GetUserByName(value).ToChatModel();
                return new OkObjectResult(user);
            }
            catch (System.Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _manager.GetAllUsers();

                return new OkObjectResult(users);
            }
            catch (System.Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}