using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using new_business_logic.User;

namespace new_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }
    }
}
