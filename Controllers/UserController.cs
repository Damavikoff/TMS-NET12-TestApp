using Microsoft.AspNetCore.Mvc;
using NET12_test.Domain.Entities;
using NET12_test.Services;

namespace NET12_test.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpPost]
        public void Update([FromBody] User user)
        {
            _userService.Add(user);
        }
    }
}
